using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace PegasusRTM.PegasusAgent
{
    public class SearchAgent
    {
        public static List<string> IgnoreWords;
        DataTable dt;
        private readonly object _Padlock = new object();
        public Dictionary<char, List<string>> keyWordsDictionary;
        ResultType rt;
        public SearchAgent(ResultType resType)
        {
            rt = resType;
            SetIgnoreWords();
            InitializeKeyWordMaps();
        }

        static void SetIgnoreWords()
        {
            if (IgnoreWords == null)
            {
                IgnoreWords = new List<string>();
                IgnoreWords.Add("a");
                IgnoreWords.Add("at");
                IgnoreWords.Add("the");
                IgnoreWords.Add("an");
                IgnoreWords.Add("of");
            }
        }
        public void SearchSpecificLog(StreamReader reader)
        {
            //FormKeyWords();
            this.dt = new DataTable();
            DataColumn dc1 = new DataColumn("col1");
            dt = new DataTable();
            dt.Columns.Add("Output", typeof(String));
            Stemmer stemmer = new Stemmer();
            List<string> currentWords;
            StringBuilder line = new StringBuilder(string.Empty);
            if (reader != null)
            {
                while (!reader.EndOfStream)
                {
                    line.Append(reader.ReadLine());
                    currentWords = line.ToString().Split(' ').ToList();
                    //currentWords = RemoveUnwantedWords(currentWords);
                    currentWords = (from strVal in currentWords
                                    where !IgnoreWords.Contains(strVal.Trim()) && !string.IsNullOrEmpty(strVal.Trim())
                                    select strVal.Trim()).ToList();
                    foreach (var item in currentWords)
                    {
                        if (!string.IsNullOrEmpty(item.Trim()))
                        {
                            if (IsWordFoundInDictioanry(stemmer.strStem(item.ToLower())))
                            {
                                this.dt.Rows.Add(line.ToString());
                                break;
                            }
                        }
                    }
                    line.Clear();
                }
                Agent.appDataSet.Tables.Add(this.dt);
            }
            else
            {
                Console.WriteLine("No Stream available");
            }
        }
        private bool IsWordFoundInDictioanry(string p)
        {
            char x = p[0];
            if (this.keyWordsDictionary.ContainsKey(p[0]))
            {
                if (this.keyWordsDictionary[(char)p.ElementAt(0)].Any(t => t.Contains(p)))
                    return true;
            }
            return false;
        }

        public void InitializeKeyWordMaps()
        {
            if (this.rt == ResultType.R1)
            {
                if (Agent.keyWordsDictionary_R1 == null)
                {
                    Agent.keyWordsDictionary_R1 = getKeyWordMap(Agent.R1);
                }
                this.keyWordsDictionary = Agent.keyWordsDictionary_R1;

            }
            else if (this.rt == ResultType.R2)
            {
                if (Agent.keyWordsDictionary_R2 == null)
                {
                    Agent.keyWordsDictionary_R2 = getKeyWordMap(Agent.R2);
                }
                this.keyWordsDictionary = Agent.keyWordsDictionary_R2;
            }
            else if (this.rt == ResultType.R3)
            {
                if (Agent.keyWordsDictionary_R3 == null)
                {
                    Agent.keyWordsDictionary_R3 = getKeyWordMap(Agent.R3);
                }
                this.keyWordsDictionary = Agent.keyWordsDictionary_R3;
            }
            else if (this.rt == ResultType.R4)
            {
                if (Agent.keyWordsDictionary_R4 == null)
                {
                    Agent.keyWordsDictionary_R4 = getKeyWordMap(Agent.R4);
                }
                this.keyWordsDictionary = Agent.keyWordsDictionary_R4;
            }
            else if (this.rt == ResultType.UserDefined)
            {
                Agent.keyWordsDictionary_UserDefined = getKeyWordMap(Agent.UserDefined);
                this.keyWordsDictionary = Agent.keyWordsDictionary_UserDefined;
            }
        }

        private Dictionary<char, List<string>> getKeyWordMap(List<string> list)
        {
            //Need to handle empty strings in List.R1
            Dictionary<char, List<string>> keyWordsDict = new Dictionary<char, List<string>>();
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    AddItemtoListInDictionary(item.ElementAt(0), item, ref keyWordsDict);
                }
            }
            return keyWordsDict;
        }

        private void AddItemtoListInDictionary(char p, string item, ref Dictionary<char, List<string>> dictKeys)
        {
            if (!dictKeys.ContainsKey(p))
            {
                dictKeys.Add(p, new List<string>() { item });
                dictKeys[p] = new List<string>() { item };
            }
            else
                dictKeys[p].Add(item);
        }

    }
}