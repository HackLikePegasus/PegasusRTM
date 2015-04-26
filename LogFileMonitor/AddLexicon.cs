using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PegasusRTM.PegasusAgent;

namespace PegasusRTM.LogFileMonitor
{
    public partial class AddLexicon : Form
    {
        public AddLexicon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var isCategoryChecked = false;
            if (cb1.Checked || cb2.Checked || cb3.Checked || cb4.Checked)
            {
                isCategoryChecked = true;
            }            
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()) && isCategoryChecked)
            {
                PegasusAgent.Agent _agent = new PegasusAgent.Agent();
                var isSuccess=_agent.AddLexiconsToResource(textBox1.Text.Trim(), cb1.Checked, cb2.Checked, cb3.Checked, cb4.Checked);
                if (isSuccess)
                {
                    this.Close();
                    MessageBox.Show("Lexicons added successfully!!");  
                }
                else
                {
                    MessageBox.Show("Sorry!! Lexicons couldnot be added.");   
                }
            }
            else if (!isCategoryChecked)
            {
                MessageBox.Show("Please select a category.");               
            }
            else
            {
                MessageBox.Show("Please enter the Keywords.");
            }
        }

    }
}
