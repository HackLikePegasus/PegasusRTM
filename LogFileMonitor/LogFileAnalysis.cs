using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PegasusRTM.PegasusAgent;
using System.Threading;
using PegasusRTM.LogFileMonitor;
using System.Configuration;
using System.IO;

namespace PegasusRTM.LogFileMonitor
{
    public partial class LogFileAnalysis : Form
    {
        public LogFileAnalysis()
        {
            InitializeComponent();
        }
        private void btnAnalyseByKw_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                char[] delimeters = { ',','~','@','.','&','|' };
                string[] keyList = textBox1.Text.Trim().Split(delimeters, StringSplitOptions.RemoveEmptyEntries);

                PegasusAgent.Agent _agent = new PegasusAgent.Agent();
                var isSuccess = _agent.AnalyzeDetails(keyList);
                if (isSuccess)
                {
                    _agent.GenerateAlertLog();
                    this.Close();
                    string alertLogPath = ConfigurationManager.AppSettings["output_logs"];
                    FileInfo newestFile = Agent.GetNewestFile(new DirectoryInfo(alertLogPath));
                    System.Diagnostics.Process.Start(newestFile.FullName);   
                }
                else
                {//can,min,bright,speed
                    MessageBox.Show("Sorry!! Something went wrong! Try Again!");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Ketwords.");
            }
        }
        private void btnAnalyseAll_Click(object sender, EventArgs e)
        {
            PegasusAgent.Agent _agent = new PegasusAgent.Agent();
            var isSuccess = _agent.AnalyzeDetails();
            if (isSuccess)
            {
                _agent.GenerateAlertLog();
                this.Close();
                string alertLogPath = ConfigurationManager.AppSettings["output_logs"];
                FileInfo newestFile = Agent.GetNewestFile(new DirectoryInfo(alertLogPath));
                System.Diagnostics.Process.Start(newestFile.FullName);            
            }
            else
            {
                MessageBox.Show("Sorry!! Something went wrong! Try Again!");
            }
        }
    }
}
