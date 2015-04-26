using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.IO;
using PegasusRTM.PegasusAgent;
using System.Threading;
using PegasusRTM.LogFileMonitor;

namespace PegasusRTM.LogMonitor
{
    public partial class WinMain : Form
    {

        long bufferChars = 5000;

        /*[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]*/
        #region WinFormLoad
        public WinMain(string[] args)
        {
            ScreenInitialization();
            // if a file was passed in, we want to open it but 
            // we have to wait until the form is fully loaded
            //if (args.Length > 0)
            //{
            //    logFileName = args[0].ToString();
            //}
        }
        private void ScreenInitialization()
        {
            InitializeComponent();
            ScreenResize(0);
        }
        private void ScreenResize(int type)
        {
            int w = 0; int h = 0;
            if (type == 0)
            {
                Rectangle resolution = Screen.PrimaryScreen.Bounds;
                w = resolution.Width;
                h = resolution.Height;
                this.Size = new System.Drawing.Size(w, h);
                this.WindowState = FormWindowState.Maximized;
            }
            else if (type == 1)
            {
                w = this.Width;
                h = this.Height;

            }

            this.tbLog.Size = new System.Drawing.Size(w / 2 - 10, h / 2 - 25);
            this.tbLog.Location = new System.Drawing.Point(0, 28);
            this.tbLog2.Size = new System.Drawing.Size(w / 2 - 10, h / 2 - 25);
            this.tbLog2.Location = new System.Drawing.Point(w / 2 - 5, 28);
            this.tbLog3.Size = new System.Drawing.Size(w / 2 - 10, h / 2 - 25);
            this.tbLog3.Location = new System.Drawing.Point(0, h / 2);
            this.tbLog4.Size = new System.Drawing.Size(w / 2 - 10, h / 2 - 25);
            this.tbLog4.Location = new System.Drawing.Point(w / 2 - 5, h / 2);

        }
        /// <summary>
        /// Once the form is fully loaded, check for command line 
        /// parameters and load the file if necessary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Tick += new System.EventHandler(this.ScrollToBottom);
            timer1.Interval = 200;
            forcedTimer.Interval = 1000;
            updateForceTimer();
            if (Agent.LoadAgentResource())
            {
                loadStatus.Text = "Loaded";
                Agent.LoadLogFile();
            }
        }
        protected override void OnResize(EventArgs e)
        {
            ScreenResize(1);
        }
        #endregion

        /// <summary>
        /// Opens a dialog to select a new file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (Agent.recentLogFiles[0] != null
                && Agent.recentLogFiles[1] != null
                && Agent.recentLogFiles[2] != null
                && Agent.recentLogFiles[3] != null)
            {
                StartMonitoring();
            }
            else
            {
                MessageBox.Show("Please click the Start button after 15 sec.");
            }

        }

        static bool IsNetworkDrive(char driveLetter)
        {
            foreach (System.IO.DriveInfo drive in System.IO.DriveInfo.GetDrives())
                if (drive.ToString()[0] == driveLetter)
                    return drive.DriveType == System.IO.DriveType.Network;

            // drive not found
            throw new ArgumentException();
        }

        /// <summary>
        /// Starts watching the selected file for changes
        /// </summary>
        private void StartMonitoring()
        {
            for (int i = 0; i < 4; i++)
            {
                var _logFileInfo = Agent.recentLogFiles[i];
                var _logFileName = _logFileInfo.FullName;
                if (_logFileName.StartsWith("\\"))
                {
                    _logFileName.Replace("\\\\", "//").Replace("\\", "//");
                }
                if (_logFileName.StartsWith("//") || IsNetworkDrive(_logFileName[0]))
                {
                    btnForced.Text = "(Network)";
                    updateForceTimer();
                }
                if (i == 0)
                {
                    fileSystemWatcher1.Path = _logFileInfo.DirectoryName;
                    fileSystemWatcher1.NotifyFilter = NotifyFilters.LastWrite;
                    fileSystemWatcher1.Filter = _logFileInfo.Name;
                    fileSystemWatcher1.Changed += new FileSystemEventHandler(this.OnChanged0);
                    UpdateDisplay(i);
                    fileSystemWatcher1.EnableRaisingEvents = true;
                }
                if (i == 1)
                {
                    fileSystemWatcher2.Path = _logFileInfo.DirectoryName;
                    fileSystemWatcher2.NotifyFilter = NotifyFilters.LastWrite;
                    fileSystemWatcher2.Filter = _logFileInfo.Name;
                    fileSystemWatcher2.Changed += new FileSystemEventHandler(this.OnChanged1);
                    UpdateDisplay(i);
                    fileSystemWatcher2.EnableRaisingEvents = true;
                }
                if (i == 2)
                {
                    fileSystemWatcher3.Path = _logFileInfo.DirectoryName;
                    fileSystemWatcher3.NotifyFilter = NotifyFilters.LastWrite;
                    fileSystemWatcher3.Filter = _logFileInfo.Name;
                    fileSystemWatcher3.Changed += new FileSystemEventHandler(this.OnChanged2);
                    UpdateDisplay(i);
                    fileSystemWatcher3.EnableRaisingEvents = true;
                }
                if (i == 3)
                {
                    fileSystemWatcher4.Path = _logFileInfo.DirectoryName;
                    fileSystemWatcher4.NotifyFilter = NotifyFilters.LastWrite;
                    fileSystemWatcher4.Filter = _logFileInfo.Name;
                    fileSystemWatcher4.Changed += new FileSystemEventHandler(this.OnChanged3);
                    UpdateDisplay(i);
                    fileSystemWatcher4.EnableRaisingEvents = true;
                }
            }
            btnPauseContinue.Text = "Pause";
        }

        /// <summary>
        /// Fired by the filesystem listener when the logfile has changed
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnChanged0(object source, FileSystemEventArgs e)
        {
            UpdateDisplay(0);
        }
        private void OnChanged1(object source, FileSystemEventArgs e)
        {
            UpdateDisplay(1);
        }
        private void OnChanged2(object source, FileSystemEventArgs e)
        {
            UpdateDisplay(2);
        }
        private void OnChanged3(object source, FileSystemEventArgs e)
        {
            UpdateDisplay(3);
        }

        /// <summary>
        /// Stops watching for changes
        /// </summary>
        private void StopMonitoring()
        {
            fileSystemWatcher1.EnableRaisingEvents = false;
            fileSystemWatcher2.EnableRaisingEvents = false;
            fileSystemWatcher3.EnableRaisingEvents = false;
            fileSystemWatcher4.EnableRaisingEvents = false;
            btnPauseContinue.Text = "Continue";
        }

        /// <summary>
        /// Fired when the user clicks the pause/continue button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPauseContinue_Click(object sender, EventArgs e)
        {
            if (btnPauseContinue.Text == "Continue")
            {
                if (Agent.recentLogFiles[0] != null
               && Agent.recentLogFiles[1] != null
               && Agent.recentLogFiles[2] != null
               && Agent.recentLogFiles[3] != null)
                {
                    StartMonitoring();
                }
                else
                {
                    MessageBox.Show("Please click the 'Continue' button after 10 sec.");
                }

            }
            else
            {
                StopMonitoring();
            }
        }

        /// <summary>
        /// Updates the textarea with the tail of the logfile and
        /// scrolls to the bottom
        /// </summary>
        private void UpdateDisplay(int i)
        {
            //String logFileName = "";
            FileInfo logFileInfo = Agent.recentLogFiles[i];
            if (logFileInfo!=null)
            {
                FileStream logFileStream = null;
                StreamReader logFileReader = null;


                try
                {
                    logFileStream = new FileStream(
                            logFileInfo.FullName,
                            FileMode.Open,
                            FileAccess.Read,
                            FileShare.ReadWrite);
                }
                catch (Exception ex)
                {
                    // tbLog.Text = "ERROR: Unable to open file: " + ex.Message;
                    switch (i)
                    {
                        case 0: tbLog.Text = "ERROR: Unable to open file: " + ex.Message;
                            break;
                        case 1: tbLog2.Text = "ERROR: Unable to open file: " + ex.Message;
                            break;
                        case 2: tbLog3.Text = "ERROR: Unable to open file: " + ex.Message;
                            break;
                        case 3: tbLog4.Text = "ERROR: Unable to open file: " + ex.Message;
                            break;
                        default:
                            break;
                    }
                }

                if (logFileStream != null)
                {
                    if (logFileStream.Length > bufferChars) logFileStream.Position = logFileStream.Length - bufferChars;
                    logFileReader = new StreamReader(logFileStream);
                    switch (i)
                    {
                        case 0: tbLog.Text = logFileReader.ReadToEnd(); break;
                        case 1: tbLog2.Text = logFileReader.ReadToEnd(); break;
                        case 2: tbLog3.Text = logFileReader.ReadToEnd(); break;
                        case 3: tbLog4.Text = logFileReader.ReadToEnd(); break;
                        default:
                            break;
                    }

                    logFileReader.Close();
                    logFileStream.Close();
                }
                else
                {
                    tbLog.Text = "ERROR: The file stream returned null";
                    switch (i)
                    {
                        case 0: tbLog.Text = "ERROR: The file stream returned null";
                            break;
                        case 1: tbLog2.Text = "ERROR: The file stream returned null";
                            break;
                        case 2: tbLog3.Text = "ERROR: The file stream returned null";
                            break;
                        case 3: tbLog4.Text = "ERROR: The file stream returned null";
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// When the main text area changes, scroll to the bottom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbLog_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void ScrollToBottom(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            tbLog.SelectionStart = tbLog.Text.Length;
            tbLog.SelectionLength = 0;
            tbLog.ScrollToCaret();
        }
       
        private void btnReload_Click(object sender, EventArgs e)
        {
            Agent.LoadLogFile();
            Thread.Sleep(500);
            if (Agent.recentLogFiles[0] != null
               && Agent.recentLogFiles[1] != null
               && Agent.recentLogFiles[2] != null
               && Agent.recentLogFiles[3] != null)
            {
                StartMonitoring();
            }
            else
            {
                MessageBox.Show("Please click the Start button after 10 sec.");
            }
        }

        /// <summary>
        /// forcedTimer is used to automatically refresh the file in the case where
        /// it is located on a network share that does not trigger the fileSystem
        /// monitoring events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forcedTimer_Tick(object sender, EventArgs e)
        {
            UpdateDisplay(0);
        }

        private void btnForced_Click(object sender, EventArgs e)
        {
            btnForced.Text = btnForced.Text == "(Local)" ? "(Network)" : "(Local)";
            updateForceTimer();
        }

        private void updateForceTimer()
        {
            forcedTimer.Enabled = btnForced.Text == "(Network)";
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            Form newForm = new LogFileAnalysis();
            newForm.Activate();
            newForm.ShowDialog(); 
        }

        private void btnAddLexicon_Click(object sender, EventArgs e)
        {
            Form newForm = new AddLexicon();
            newForm.Activate();
            newForm.ShowDialog(); 
        }
    }
}
