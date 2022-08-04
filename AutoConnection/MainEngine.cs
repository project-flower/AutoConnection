using AutoConnection.Events;
using NativeApi;
using System;
using System.Text;
using System.Windows.Automation;

namespace AutoConnection
{
    public class MainEngine : IDisposable
    {
        #region Private Fields

        private bool enabled = false;
        private IntPtr hWinEventHook = IntPtr.Zero;
        private readonly WINEVENTPROC winEventProc;
        private readonly WNDENUMPROC wndEnumProc;

        #endregion

        #region Public Properties

        public bool Enabled
        {
            get
            {
                return enabled;
            }

            set
            {
                if (enabled == value) return;

                if (value)
                {
                    hWinEventHook = User32.SetWinEventHook(EVENT_OBJECT.SHOW, EVENT_OBJECT.SHOW, IntPtr.Zero, winEventProc, 0, 0, (WINEVENT.OUTOFCONTEXT | WINEVENT.SKIPOWNPROCESS));
                    enabled = (hWinEventHook != IntPtr.Zero);
                }
                else
                {
                    if (hWinEventHook == IntPtr.Zero) return;

                    User32.UnhookWinEvent(hWinEventHook);
                    hWinEventHook = IntPtr.Zero;
                    enabled = false;
                }
            }
        }

        public event ErrorOccurredEventHandler ErrorOccurred = delegate { };
        public WindowParameters[] WindowParameters { get; set; }

        #endregion

        #region Public Methods

        public MainEngine()
        {
            winEventProc = new WINEVENTPROC(WinEventProc);
            wndEnumProc = new WNDENUMPROC(WndEnumProc);
            AutomationElementHelper.PropertyConditionFlags = PropertyConditionFlags.IgnoreCase;
            Enabled = true;
        }

        public void CheckWindows()
        {
            User32.EnumWindows(wndEnumProc, IntPtr.Zero);
        }

        public void Dispose()
        {
            Enabled = false;
        }

        #endregion

        #region Private Methods

        private void AnalyzeWindow(IntPtr hwnd)
        {
            if (WindowParameters == null) return;

            foreach (WindowParameters parameters in WindowParameters)
            {
                try
                {
                    AnalyzeWindow(hwnd, parameters);
                }
                catch (Exception exception)
                {
                    ErrorOccurred(this, new ErrorOccurredEventArgs(exception.Message));
                }
            }
        }

        private bool AnalyzeWindow(IntPtr hwnd, WindowParameters parameters)
        {
            var builder = new StringBuilder(1024);

            try
            {
                User32.GetWindowText(hwnd, builder, builder.Capacity);

                if (builder.ToString() != parameters.WindowTitle) return false;

                bool descriptionFound = string.IsNullOrEmpty(parameters.Description);
                AutomationElement automationElement = AutomationElement.FromHandle(hwnd);
                ValuePattern userName = null;
                ValuePattern password = null;
                InvokePattern button = null;
                bool foundAllElements = false;

                foreach (AutomationElement element in automationElement.FindAll(TreeScope.Descendants, Condition.TrueCondition))
                {
                    if (descriptionFound && (userName != null) && (password != null) && (button != null))
                    {
                        foundAllElements = true;
                        break;
                    }

                    if (!descriptionFound && !string.IsNullOrEmpty(parameters.Description) && element.AnalyzeElement(parameters.DescriptionClassName, parameters.DescriptionControlName, parameters.Description))
                    {
                        descriptionFound = true;
                        continue;
                    }

                    if ((userName == null) && element.AnalyzeElement(parameters.UserNameClassName, parameters.UserNameControlName))
                    {
                        userName = element.GetCurrentValuePattern();
                        continue;
                    }

                    if ((password == null) && element.AnalyzeElement(parameters.PasswordClassName, parameters.PasswordControlName))
                    {
                        password = element.GetCurrentValuePattern();
                        continue;
                    }

                    if ((button == null) && element.AnalyzeElement(parameters.ButtonClassName, parameters.ButtonControlName, parameters.ButtonText))
                    {
                        button = element.GetCurrentInvokePattern();
                        continue;
                    }
                }

                if (!foundAllElements)
                {
                    return false;
                }

                userName.SetValue(parameters.UserName);
                password.SetValue(parameters.Password);
                button.Invoke();
                return true;
            }
            catch (Exception exception)
            {
                ErrorOccurred(this, new ErrorOccurredEventArgs(exception.Message));
            }

            return false;
        }

        private void WinEventProc(IntPtr hWinEventHook, uint event_, IntPtr hwnd, int idObject, int idChild, uint idEventThread, uint dwmsEventTime)
        {
            AnalyzeWindow(hwnd);
        }

        private bool WndEnumProc(IntPtr hWnd, IntPtr lParam)
        {
            AnalyzeWindow(hWnd);
            return true;
        }

        #endregion
    }
}
