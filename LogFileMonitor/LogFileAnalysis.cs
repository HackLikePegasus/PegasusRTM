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
            //if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            //{
            //    char[] delimeters = { ',' };
            //    string[] keyList = textBox1.Text.Trim().Split(delimeters, StringSplitOptions.RemoveEmptyEntries);

            //    PegasusAgent.Agent _agent = new PegasusAgent.Agent();
            //    var isSuccess = _agent.AnalyzeDetails(keyList);
            //        //_agent.AddLexiconsToResource(textBox1.Text.Trim(), cb1.Checked, cb2.Checked, cb3.Checked, cb4.Checked);
            //    if (isSuccess)
            //    {
            //        this.Close();
            //        MessageBox.Show("Lexicons added successfully!!");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Sorry!! Lexicons couldnot be added.");
            //    }
            //}
        }

        private void btnAnalyseAll_Click(object sender, EventArgs e)
        {
            PegasusAgent.Agent _agent = new PegasusAgent.Agent();
            var isSuccess = _agent.AnalyzeDetails();
        }
    }
}
