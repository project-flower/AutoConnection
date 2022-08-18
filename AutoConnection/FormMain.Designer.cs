namespace AutoConnection
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxSettingFileName = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.configView = new AutoConnection.ConfigView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSettingFileName
            // 
            this.textBoxSettingFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSettingFileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxSettingFileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.textBoxSettingFileName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::AutoConnection.Properties.Settings.Default, "SettingFileName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxSettingFileName.Location = new System.Drawing.Point(12, 12);
            this.textBoxSettingFileName.Name = "textBoxSettingFileName";
            this.textBoxSettingFileName.Size = new System.Drawing.Size(776, 19);
            this.textBoxSettingFileName.TabIndex = 0;
            this.textBoxSettingFileName.Text = global::AutoConnection.Properties.Settings.Default.SettingFileName;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoad.Location = new System.Drawing.Point(632, 37);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "読み込み(&L)";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(713, 37);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "保存(&S)";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // configView
            // 
            this.configView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configView.Location = new System.Drawing.Point(12, 66);
            this.configView.Name = "configView";
            this.configView.Size = new System.Drawing.Size(776, 343);
            this.configView.TabIndex = 3;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(551, 415);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "追加(&A)";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Location = new System.Drawing.Point(632, 415);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 5;
            this.buttonRemove.Text = "削除(&R)";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(713, 415);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 6;
            this.buttonApply.Text = "適用(&P)";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEnabled,
            this.toolStripMenuItemSetting,
            this.toolStripSeparator1,
            this.toolStripMenuItemExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(114, 76);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // toolStripMenuItemEnabled
            // 
            this.toolStripMenuItemEnabled.Name = "toolStripMenuItemEnabled";
            this.toolStripMenuItemEnabled.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItemEnabled.Text = "有効(&E)";
            this.toolStripMenuItemEnabled.Click += new System.EventHandler(this.toolStripMenuItemEnabled_Click);
            // 
            // toolStripMenuItemSetting
            // 
            this.toolStripMenuItemSetting.Name = "toolStripMenuItemSetting";
            this.toolStripMenuItemSetting.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItemSetting.Text = "設定(&S)";
            this.toolStripMenuItemSetting.Click += new System.EventHandler(this.toolStripMenuItemSetting_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(110, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItemExit.Text = "終了(&X)";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Text = "AutoConnection";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.configView);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.textBoxSettingFileName);
            this.Name = "FormMain";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Text = "AutoConnection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            this.Load += new System.EventHandler(this.load);
            this.Shown += new System.EventHandler(this.shown);
            this.VisibleChanged += new System.EventHandler(this.visibleChanged);
            this.Resize += new System.EventHandler(this.resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSettingFileName;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private ConfigView configView;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEnabled;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
    }
}

