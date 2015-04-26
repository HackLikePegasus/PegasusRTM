using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Configuration;

namespace PegasusRTM.PegasusAgent
{
    public partial class Agent
    {
        private static Mutex mutex = new Mutex();
        private const int numhits = 1;
        private const int numThreads = 4;
        public static List<string> R1 = new List<string>();
        public static List<string> R2 = new List<string>();
        public static List<string> R3 = new List<string>();
        public static List<string> R4 = new List<string>();
        public static string[] configValue = new string[4];
        public static FileInfo[] recentLogFiles = new FileInfo[4];
        public static FileInfo[] oldLogFiles = new FileInfo[4]; 
        
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
            catch(Exception e)
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

            // Example #1 
            // Read the file as one string. 
            if (File.Exists(filename))
            {
                string text = System.IO.File.ReadAllText(filename);
                if (type.Equals("R1"))
                {
                    R1 = text.Split(',').ToList();
                }
                else if (type.Equals("R2"))
                {
                    R2 = text.Split(',').ToList();
                }
                else if (type.Equals("R3"))
                {
                    R3 = text.Split(',').ToList();
                }
                else
                {
                    R4 = text.Split(',').ToList();
                }
                //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
            }

            // Display the file contents to the console. Variable text is a string.
            //// Example #2 
            //// Read each line of the file into a string array. Each element 
            //// of the array is one line of the file. 
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");

            //// Display the file contents by using a foreach loop.
            //System.Console.WriteLine("Contents of WriteLines2.txt = ");
            //foreach (string line in lines)
            //{
            //    // Use a tab to indent each line of the file.
            //    Console.WriteLine("\t" + line);
            //}

            //// Keep the console window open in debug mode.
            //Console.WriteLine("Press any key to exit.");
            // System.Console.ReadKey();
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
    }

}
