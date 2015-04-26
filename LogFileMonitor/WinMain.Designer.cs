namespace PegasusRTM.LogMonitor
{
	partial class WinMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinMain));
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSelectFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPauseContinue = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.btnForced = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddLexicon = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAnalyze = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.forcedTimer = new System.Windows.Forms.Timer(this.components);
            this.tbLog2 = new System.Windows.Forms.TextBox();
            this.tbLog3 = new System.Windows.Forms.TextBox();
            this.tbLog4 = new System.Windows.Forms.TextBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.loadStatus = new System.Windows.Forms.Label();
            this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
            this.fileSystemWatcher3 = new System.IO.FileSystemWatcher();
            this.fileSystemWatcher4 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher4)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSelectFile,
            this.toolStripSeparator2,
            this.btnPauseContinue,
            this.toolStripSeparator1,
            this.btnReload,
            this.btnForced,
            this.toolStripSeparator3,
            this.btnAddLexicon,
            this.toolStripSeparator4,
            this.btnAnalyze});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1249, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSelectFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSelectFile.ImageTransparentColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(35, 22);
            this.btnSelectFile.Text = "Start";
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPauseContinue
            // 
            this.btnPauseContinue.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPauseContinue.Name = "btnPauseContinue";
            this.btnPauseContinue.Size = new System.Drawing.Size(42, 22);
            this.btnPauseContinue.Text = "Pause";
            this.btnPauseContinue.Click += new System.EventHandler(this.btnPauseContinue_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnReload
            // 
            this.btnReload.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(94, 22);
            this.btnReload.Text = "Check New Log";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnForced
            // 
            this.btnForced.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnForced.Image = ((System.Drawing.Image)(resources.GetObject("btnForced.Image")));
            this.btnForced.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnForced.Name = "btnForced";
            this.btnForced.Size = new System.Drawing.Size(47, 22);
            this.btnForced.Text = "(Local)";
            this.btnForced.Click += new System.EventHandler(this.btnForced_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddLexicon
            // 
            this.btnAddLexicon.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAddLexicon.Name = "btnAddLexicon";
            this.btnAddLexicon.Size = new System.Drawing.Size(81, 22);
            this.btnAddLexicon.Text = "Add Lexicons";
            this.btnAddLexicon.Click += new System.EventHandler(this.btnAddLexicon_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(92, 22);
            this.btnAnalyze.Text = "Analyze-Report";
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // forcedTimer
            // 
            this.forcedTimer.Tick += new System.EventHandler(this.forcedTimer_Tick);
            // 
            // tbLog2
            // 
            this.tbLog2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbLog2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLog2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbLog2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLog2.ForeColor = System.Drawing.Color.LimeGreen;
            this.tbLog2.Location = new System.Drawing.Point(210, 28);
            this.tbLog2.Multiline = true;
            this.tbLog2.Name = "tbLog2";
            this.tbLog2.ReadOnly = true;
            this.tbLog2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog2.Size = new System.Drawing.Size(200, 75);
            this.tbLog2.TabIndex = 6;
            this.tbLog2.Text = "Select a file to begin monitoring...";
            this.tbLog2.WordWrap = false;
            // 
            // tbLog3
            // 
            this.tbLog3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbLog3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLog3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbLog3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLog3.ForeColor = System.Drawing.Color.LimeGreen;
            this.tbLog3.Location = new System.Drawing.Point(0, 80);
            this.tbLog3.Multiline = true;
            this.tbLog3.Name = "tbLog3";
            this.tbLog3.ReadOnly = true;
            this.tbLog3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog3.Size = new System.Drawing.Size(200, 75);
            this.tbLog3.TabIndex = 7;
            this.tbLog3.Text = "Select a file to begin monitoring...";
            this.tbLog3.WordWrap = false;
            // 
            // tbLog4
            // 
            this.tbLog4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbLog4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLog4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbLog4.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLog4.ForeColor = System.Drawing.Color.LimeGreen;
            this.tbLog4.Location = new System.Drawing.Point(210, 80);
            this.tbLog4.Multiline = true;
            this.tbLog4.Name = "tbLog4";
            this.tbLog4.ReadOnly = true;
            this.tbLog4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog4.Size = new System.Drawing.Size(200, 75);
            this.tbLog4.TabIndex = 8;
            this.tbLog4.Text = "Select a file to begin monitoring...";
            this.tbLog4.WordWrap = false;
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLog.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLog.ForeColor = System.Drawing.Color.LimeGreen;
            this.tbLog.Location = new System.Drawing.Point(0, 28);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(200, 75);
            this.tbLog.TabIndex = 2;
            this.tbLog.Text = "Select a file to begin monitoring...";
            this.tbLog.WordWrap = false;
            this.tbLog.TextChanged += new System.EventHandler(this.tbLog_TextChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(1000, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 13);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Resource:";
            // 
            // loadStatus
            // 
            this.loadStatus.AutoSize = true;
            this.loadStatus.Location = new System.Drawing.Point(1072, 8);
            this.loadStatus.Name = "loadStatus";
            this.loadStatus.Size = new System.Drawing.Size(63, 13);
            this.loadStatus.TabIndex = 10;
            this.loadStatus.Text = "Not Loaded";
            // 
            // fileSystemWatcher2
            // 
            this.fileSystemWatcher2.EnableRaisingEvents = true;
            this.fileSystemWatcher2.SynchronizingObject = this;
            // 
            // fileSystemWatcher3
            // 
            this.fileSystemWatcher3.EnableRaisingEvents = true;
            this.fileSystemWatcher3.SynchronizingObject = this;
            // 
            // fileSystemWatcher4
            // 
            this.fileSystemWatcher4.EnableRaisingEvents = true;
            this.fileSystemWatcher4.SynchronizingObject = this;
            // 
            // WinMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 453);
            this.Controls.Add(this.loadStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tbLog4);
            this.Controls.Add(this.tbLog3);
            this.Controls.Add(this.tbLog2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tbLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WinMain";
            this.Text = "Pegasus rt-monitor";
            this.Load += new System.EventHandler(this.WinMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnPauseContinue;
		private System.Windows.Forms.ToolStripButton btnSelectFile;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton btnAnalyze;
        private System.Windows.Forms.Timer forcedTimer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnForced;
        private System.Windows.Forms.TextBox tbLog4;
        private System.Windows.Forms.TextBox tbLog3;
        private System.Windows.Forms.TextBox tbLog2;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label loadStatus;
        private System.IO.FileSystemWatcher fileSystemWatcher2;
        private System.IO.FileSystemWatcher fileSystemWatcher3;
        private System.IO.FileSystemWatcher fileSystemWatcher4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnAddLexicon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
	}
}

