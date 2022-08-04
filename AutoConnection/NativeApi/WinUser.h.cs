using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NativeApi
{
    public static partial class EVENT_OBJECT
    {
        #region Public Fields

        /// <summary>hwnd + ID + idChild is created item</summary>
        public const uint CREATE  = 0x8000;
        /// <summary>hwnd + ID + idChild is destroyed item</summary>
        public const uint DESTROY = 0x8001;
        /// <summary>hwnd + ID + idChild is shown item</summary>
        public const uint SHOW    = 0x8002;
        /// <summary>hwnd + ID + idChild is hidden item</summary>
        public const uint HIDE    = 0x8003;
        /// <summary>hwnd + ID + idChild is parent of zordering children</summary>
        public const uint REORDER = 0x8004;

        #endregion
    }

    public static partial class User32
    {
        #region Public Methods

        [DllImport(AssemblyName)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(WNDENUMPROC lpEnumFunc, IntPtr lParam);

        [DllImport(AssemblyName, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport(AssemblyName)]
        public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WINEVENTPROC pfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        [DllImport(AssemblyName)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        #endregion
    }

    /// <summary>
    /// dwFlags for SetWinEventHook
    /// </summary>
    public static partial class WINEVENT
    {
        #region Public Fields

        /// <summary>Events are ASYNC</summary>
        public const uint OUTOFCONTEXT   = 0x0000;
        /// <summary>Don't call back for events on installer's thread</summary>
        public const uint SKIPOWNTHREAD  = 0x0001;
        /// <summary>Don't call back for events on installer's process</summary>
        public const uint SKIPOWNPROCESS = 0x0002;
        /// <summary>Events are SYNC, this causes your dll to be injected into every process</summary>
        public const uint INCONTEXT      = 0x0004;

        #endregion
    }

    public delegate void WINEVENTPROC(IntPtr hWinEventHook, uint event_, IntPtr hwnd, int idObject, int idChild, uint idEventThread, uint dwmsEventTime);
    public delegate bool WNDENUMPROC(IntPtr hWnd, IntPtr lParam);
}
