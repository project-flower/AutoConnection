using AutoConnection.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace AutoConnection
{
    public partial class FormMain : Form
    {
        #region Private Fields

        private string launchErrorMessage;
        private readonly MainEngine mainEngine;
        private FormWindowState prevWindowState;
        private const double visibleOpacity = 1.0D;
        private bool windowRequired = false;

        #endregion

        #region Public Methods

        public FormMain()
        {
            InitializeComponent();
            MinimumSize = Size;
            prevWindowState = WindowState;
            mainEngine = new MainEngine();
        }

        #endregion

        #region Private Methods

        private void LoadSettings()
        {
            WindowParameters[] parameters = WindowParameters.LoadFromFile(Settings.Default.SettingFileName);
            configView.SetParameters(parameters);
            mainEngine.WindowParameters = parameters;
        }

        private bool PrepairSettingFile()
        {
            string settingFileName = Settings.Default.SettingFileName;

            if (!File.Exists(settingFileName))
            {
                WindowParameters.SaveTo(settingFileName, WindowParameters.Sample());
                return true;
            }

            return false;
        }

        private void RestoreWindow()
        {
            windowRequired = true;
            Show();
            WindowState = prevWindowState;
        }

        private void SaveSettings()
        {
            WindowParameters.SaveTo(textBoxSettingFileName.Text, configView.GetParameters());
            Settings.Default.Save();
        }

        private void SetEnabled(bool enabled)
        {
            mainEngine.Enabled = enabled;

            if (mainEngine.Enabled)
            {
                notifyIcon.Icon = Resources.Small;
            }
            else
            {
                notifyIcon.Icon = Resources.Gray;
            }
        }

        private void ShowErrorMessage(string message)
        {
            ShowMessage(message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private DialogResult ShowMessage(string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(this, text, Text, buttons, icon);
        }

        #endregion

        // Designer's Methods

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            configView.Add();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            mainEngine.WindowParameters = configView.GetParameters();
            ShowMessage("設定が適用されました。", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (ShowMessage("設定を読み込みます。よろしいですか？", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;

            mainEngine.WindowParameters = null;
            configView.Initialize();

            try
            {
                LoadSettings();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (ShowMessage("現在のタブを削除します。よろしいですか？", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;

            mainEngine.WindowParameters = null;
            configView.Remove();
            mainEngine.WindowParameters = configView.GetParameters();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
                ShowMessage("設定を保存しました。", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            toolStripMenuItemEnabled.Checked = mainEngine.Enabled;
        }

        private void formClosed(object sender, FormClosedEventArgs e)
        {
            mainEngine.Dispose();
        }

        private void load(object sender, EventArgs e)
        {
            bool initial = false;

            try
            {
                if (PrepairSettingFile())
                {
                    initial = true;
                    windowRequired = true;
                }
            }
            catch (Exception exception)
            {
                launchErrorMessage = exception.Message;
                windowRequired = true;
                return;
            }

            try
            {
                LoadSettings();
            }
            catch (Exception exception)
            {
                launchErrorMessage = exception.Message;
                windowRequired = true;
            }

            if (!initial) mainEngine.CheckWindows();

            SetEnabled(!initial);
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) mainEngine.CheckWindows();
        }

        private void resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
            else
            {
                prevWindowState = WindowState;
            }
        }

        private void shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(launchErrorMessage))
            {
                ShowErrorMessage(string.Format("起動時にエラーが発生しました。{0}{0}{1}", Environment.NewLine, launchErrorMessage));
            }
        }

        private void toolStripMenuItemEnabled_Click(object sender, EventArgs e)
        {
            SetEnabled(!(mainEngine.Enabled));
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItemSetting_Click(object sender, EventArgs e)
        {
            RestoreWindow();
        }

        private void visibleChanged(object sender, EventArgs e)
        {
            // 起動時にウィンドウを表示させずにウィンドウ プロシージャを動作させるための仕組み

            if (!windowRequired && Visible)
            {
                Hide();
                return;
            }

            if (Visible)
            {
                if (Opacity != visibleOpacity)
                {
                    Opacity = visibleOpacity;
                }

                if (!ShowInTaskbar)
                {
                    ShowInTaskbar = true;
                }

                windowRequired = false;
            }
        }
    }
}
