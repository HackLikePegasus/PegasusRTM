namespace PegasusRTM.LogFileMonitor
{
    partial class LogFileAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogFileAnalysis));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAnalyseByKw = new System.Windows.Forms.Button();
            this.btnAnalyseAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(34, 26);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(373, 40);
            this.textBox1.TabIndex = 3;
            // 
            // btnAnalyseByKw
            // 
            this.btnAnalyseByKw.Location = new System.Drawing.Point(111, 72);
            this.btnAnalyseByKw.Name = "btnAnalyseByKw";
            this.btnAnalyseByKw.Size = new System.Drawing.Size(198, 23);
            this.btnAnalyseByKw.TabIndex = 4;
            this.btnAnalyseByKw.Text = "Analyze By Entered Kweyword(s)";
            this.btnAnalyseByKw.UseVisualStyleBackColor = true;
            this.btnAnalyseByKw.Click += new System.EventHandler(this.btnAnalyseByKw_Click);
            // 
            // btnAnalyseAll
            // 
            this.btnAnalyseAll.Location = new System.Drawing.Point(111, 101);
            this.btnAnalyseAll.Name = "btnAnalyseAll";
            this.btnAnalyseAll.Size = new System.Drawing.Size(198, 23);
            this.btnAnalyseAll.TabIndex = 5;
            this.btnAnalyseAll.Text = "Overall Analysis";
            this.btnAnalyseAll.UseVisualStyleBackColor = true;
            this.btnAnalyseAll.Click += new System.EventHandler(this.btnAnalyseAll_Click);
            // 
            // LogFileAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 155);
            this.Controls.Add(this.btnAnalyseAll);
            this.Controls.Add(this.btnAnalyseByKw);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogFileAnalysis";
            this.Text = "LogFileAnalysis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAnalyseByKw;
        private System.Windows.Forms.Button btnAnalyseAll;

    }
}