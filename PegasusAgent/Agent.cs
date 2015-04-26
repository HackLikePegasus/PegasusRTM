using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Configuration;
using System.Data;

namespace PegasusRTM.PegasusAgent
{

    public enum ResultType
    {
        R1, R2, R3, R4,UserDefined
    }
    public partial class Agent
    {
        private static Mutex mutex = new Mutex();
        private const int numhits = 1;
        private const int numThreads = 4;
        public static List<string> R1 = new List<string>();
        public static List<string> R2 = new List<string>();
        public static List<string> R3 = new List<string>();
        public static List<string> R4 = new List<string>();
        public static List<string> UserDefined = new List<string>();
        public static string[] configValue = new string[4];
        public static FileInfo[] recentLogFiles = new FileInfo[4];
        public static FileInfo[] oldLogFiles = new FileInfo[4];
        public static DataSet appDataSet = new DataSet();
        public static Dictionary<char, List<string>> keyWordsDictionary_R1;
        public static Dictionary<char, List<string>> keyWordsDictionary_R2;
        public static Dictionary<char, List<string>> keyWordsDictionary_R3;
        public static Dictionary<char, List<string>> keyWordsDictionary_R4;
        public static Dictionary<char, List<string>> keyWordsDictionary_UserDefined;

        public static bool LoadAgentResource()
        {
            try
            {
                for (int i = 0; i < numThreads; i++)
                {
                    Thread mycorner = new Thread(new ThreadStart(ThreadProcess));
                    mycorner.Name = String.Format("R{0}", i + 1);
                    mycorner.Start();
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        private static void ThreadProcess()
        {
            LoadResourceFileThreaded();
        }
        private static void LoadResourceFileThreaded()
        {
            mutex.WaitOne();   // Wait until it is safe to enter.
            var name = Thread.CurrentThread.Name;
            var resourcePath = Directory.GetParent(Directory.GetCurrentDirectory());
            var strPath = string.Format(@"{0}\{1}\{2}.txt", resourcePath, "AgentResource", name);
            ReadBaseFiles(strPath, name);
            // Place code to access non-reentrant resources here.
            Thread.Sleep(500);    // Wait until it is safe to enter.
            mutex.ReleaseMutex();    // Release the Mutex.
        }
        private static void ReadBaseFiles(string filename, string type)
        {
            // The files used in this example are created in the topic 
            // How to: Write to a Text File. You can change the path and 
            // file name to substitute text files of your own. 

            // Read the file as one string. 
            if (File.Exists(filename))
            {
                char[] delimeters = { ',' };
                string text = System.IO.File.ReadAllText(filename);
                if (type.Equals("R1"))
                {
                    R1 = text.Split(delimeters, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                else if (type.Equals("R2"))
                {
                    R2 = text.Split(delimeters, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                else if (type.Equals("R3"))
                {
                    R3 = text.Split(delimeters, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                else
                {
                    R4 = text.Split(delimeters, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
            }
        }

        public static void LoadLogFile()
        {
            configValue[0] = ConfigurationManager.AppSettings["log_web"];
            configValue[1] = ConfigurationManager.AppSettings["log_nwevent"];
            configValue[2] = ConfigurationManager.AppSettings["log_err"];
            configValue[3] = ConfigurationManager.AppSettings["log_clicks"];
            for (int i = 0; i < configValue.Length; i++)
            {
                Thread fileprocess = new Thread(new ThreadStart(ThreadLogFileLoadProcess));
                fileprocess.Name = String.Format("{0}", i + 1);
                fileprocess.Start();
            }
        }
        private static void ThreadLogFileLoadProcess()
        {
            LoadLogFileThreaded();
        }
        private static void LoadLogFileThreaded()
        {
            mutex.WaitOne();   // Wait until it is safe to enter.
            var path = configValue[(Convert.ToInt32(Thread.CurrentThread.Name) - 1)];
            if (Directory.Exists(path))
            {
                FileInfo newestFile = GetNewestFile(new DirectoryInfo(path));
                recentLogFiles[(Convert.ToInt32(Thread.CurrentThread.Name) - 1)] = newestFile;

            }
            // Place code to access non-reentrant resources here.
            Thread.Sleep(500);    // Wait until it is safe to enter.
            mutex.ReleaseMutex();    // Release the Mutex.
        }
        public static FileInfo GetNewestFile(DirectoryInfo directory)
        {
            return directory.GetFiles()
                .Union(directory.GetDirectories().Select(d => GetNewestFile(d)))
                .OrderByDescending(f => (f == null ? DateTime.MinValue : f.LastWriteTime))
                .FirstOrDefault();
        }

        public bool AddLexiconsToResource(string lexicons, bool r1 = false, bool r2 = false, bool r3 = false, bool r4 = false)
        {
            try
            {
                var filenameList = "";
                if (r1)
                {
                    filenameList += "R1";
                }
                if (r2)
                {
                    filenameList += ",R2";
                }
                if (r3)
                {
                    filenameList += ",R3";
                }
                if (r4)
                {
                    filenameList += ",R4";
                }
                AddToFile(lexicons, filenameList);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        private void AddToFile(string lexiconString, string filenameList)
        {
            var resourcePath = Directory.GetParent(Directory.GetCurrentDirectory());

            foreach (var item in filenameList.Split(','))
            {
                var filename = string.Format(@"{0}\{1}\{2}.txt", resourcePath, "AgentResource", item.Trim());
                if (File.Exists(filename))
                {
                    string[] compareRList = null;
                    if (item.Equals("R1"))
                    {
                        compareRList = R1.ToArray();
                    }
                    else if (item.Equals("R2"))
                    {
                        compareRList = R2.ToArray();
                    }
                    else if (item.Equals("R3"))
                    {
                        compareRList = R3.ToArray();
                    }
                    else
                    {
                        compareRList = R4.ToArray();
                    }
                    char[] delimeters = { ',' };
                    string[] sList = lexiconString.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                    if (compareRList.Count() > 0 && sList.Count() > 0)
                    {
                        var slist = from string strVal in sList
                                    where strVal.Trim() != ""
                                    select strVal.Trim();
                        var foundList = from string strVal in compareRList
                                        where slist.Contains(strVal)
                                        select strVal.Trim();
                        if (foundList.Count() == 0)
                        {
                            File.AppendAllText(filename, "," + string.Join(",", slist));
                            if (item.Equals("R1"))
                            {
                                R1.AddRange(slist.ToList());
                            }
                            else if (item.Equals("R2"))
                            {
                                R2.AddRange(slist.ToList());
                            }
                            else if (item.Equals("R3"))
                            {
                                R3.AddRange(slist.ToList());
                            }
                            else
                            {
                                R4.AddRange(slist.ToList());
                            }
                        }
                    }
                }
            }


        }
        public bool AnalyzeDetails(string[] keyList = null)
        {
            try
            {
                if (keyList != null)
                {
                    // to be implemented.. istead of R1,R2,R3,R4 take these are the search items 'keyList'.
                    SearchAgent s = new SearchAgent(ResultType.UserDefined);
                    Agent.UserDefined = keyList.ToList();
                    using (StreamReader sr = new StreamReader(recentLogFiles[0].FullName))
                    {                      
                        s.SearchSpecificLog(sr);
                    }
                    using (StreamReader sr = new StreamReader(recentLogFiles[1].FullName))
                    {
                        s.SearchSpecificLog(sr);
                    }
                    using (StreamReader sr = new StreamReader(recentLogFiles[2].FullName))
                    {
                        s.SearchSpecificLog(sr);
                    }
                    using (StreamReader sr = new StreamReader(recentLogFiles[3].FullName))
                    {
                        s.SearchSpecificLog(sr);
                    }
                    s = null;

                }
                else
                {
                    SearchAgent s = null;
                    Agent.UserDefined = new List<string>();
                    using (StreamReader sr = new StreamReader(recentLogFiles[0].FullName))
                    {
                         s = new SearchAgent(ResultType.R1);
                        s.SearchSpecificLog(sr);
                    }
                    using (StreamReader sr = new StreamReader(recentLogFiles[1].FullName))
                    {
                        s = new SearchAgent(ResultType.R2);
                        s.SearchSpecificLog(sr);
                    }
                    using (StreamReader sr = new StreamReader(recentLogFiles[2].FullName))
                    {
                        s = new SearchAgent(ResultType.R3);
                        s.SearchSpecificLog(sr);
                    }
                    using (StreamReader sr = new StreamReader(recentLogFiles[3].FullName))
                    {
                        s = new SearchAgent(ResultType.R4);
                        s.SearchSpecificLog(sr);
                    }                    
                    s = null;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }
        public void GenerateAlertLog()
        {
            string alertLogPath = ConfigurationManager.AppSettings["output_logs"];
            var fileName = string.Format("{0}\\{1}_{2:MMddyyyy_hhmmss}.txt", alertLogPath, "LogReportOut", DateTime.Now);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                file.WriteLine(string.Format("The below are the oservations in file name - {0}", fileName));
                file.WriteLine("**************************************************************************");
                foreach (DataTable table in appDataSet.Tables)
                {
                    switch (table.TableName)
                    {
                        case "Table1": file.WriteLine("-----------------[Security Concerns Related - Highlights]----------------");
                            break;
                        case "Table2": file.WriteLine("-----------------[Customer Experience Related - Highlights]--------------");
                            break;
                        case "Table3": file.WriteLine("-----------------[Issues with App-Performance - Highlights]--------------");
                            break;
                        case "Table4": file.WriteLine("-----------------[Peak time Performace - Highlights]---------------------");
                            break;
                        default:
                            break;
                    }
                    file.WriteLine("");
                    foreach (DataRow row in table.Rows)
                    {
                        // If the line doesn't contain the word 'Second', write the line to the file. 
                        file.WriteLine(row.ItemArray[0].ToString());
                    }
                    file.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                    file.WriteLine("-----------------[  [  [ Highlight Section Ends ]  ]  ]-----------------");
                }
                file.WriteLine("****************************End**********************************************");
            }

            appDataSet.Clear();
        }

    }

}
