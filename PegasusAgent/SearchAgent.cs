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
        Dictionary<char, List<string>> keyWordsDictionary;
        ResultType rt;
        public SearchAgent(ResultType resType)
        {
            rt = resType;
            SetIgnoreWords();
        }

        static void SetIgnoreWords()
        {
            IgnoreWords.Add("a");
            IgnoreWords.Add("at");
            IgnoreWords.Add("the");
            IgnoreWords.Add("an");
            IgnoreWords.Add("of");
        }



        public void SearchSpecificLog(StreamReader reader)
        {
            //FormKeyWords();
            dt = new DataTable();
            //dt.Rows.Add
            Stemmer stemmer = new Stemmer();
            //List<string> matchedKeyWords = new List<string>();
            List<string> currentWords;
            StringBuilder line = new StringBuilder(string.Empty);
            if (reader != null)
            {
                while (true)
                {
                    if (!reader.EndOfStream)
                    {
                        line.Append(reader.ReadLine());
                        currentWords = line.ToString().Split(' ').ToList();
                        currentWords = RemoveUnwantedWords(currentWords);

                        foreach (var item in currentWords)
                        {
                            if (IsWordFoundInDictioanry(stemmer.strStem(item.ToLower())))
                            {
                                dt.Rows.Add(line.ToString());
                                break;
                            }
                        }
                        line.Clear();
                    }
                    else
                    break;
                }
                Agent.appDataSet.Tables.Add(dt); 
            }
            else
            {
                Console.WriteLine("No Stream available");
            }
        }

        private bool IsWordFoundInDictioanry(string p)
        {
            if (keyWordsDictionary[p.ElementAt(0)].Any(t => t.Contains(p)))
                return true;
            return false;
        }

        private List<string> RemoveUnwantedWords(List<string> currentWords)
        {
            foreach (var item in currentWords)
            {
                if (string.IsNullOrEmpty(item))
                    currentWords.Remove(item);
                else
                {
                    currentWords.ToList().ForEach(t =>
                    {
                        if (IgnoreWords.Select(ig => ig.Equals(t.ToLower())).Any())
                        { currentWords.Remove(t); }
                    });
                }
            }
            return currentWords;
        }

        public void InitializeKeyWordMaps()
        {
            if (this.rt == ResultType.Performance)
            {
                //Need to Initialize caching
                keyWordsDictionary = getKeyWordMap(Agent.R1);
            }
            else if (this.rt == ResultType.Security)
            {
                //Need to Initialize caching
                keyWordsDictionary = getKeyWordMap(Agent.R2);
            }
            else if (this.rt == ResultType.SomeThingElse)
            {
                //Need to Initialize caching
                keyWordsDictionary = getKeyWordMap(Agent.R3);
            }
            else if (this.rt == ResultType.UserExperience)
            {
                //Need to Initialize caching
                keyWordsDictionary = getKeyWordMap(Agent.R4);
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
            if (dictKeys[p] == null)
            {
                dictKeys[p] = new List<string>() { item };
            }
            else
                dictKeys[p].Add(item);
        }

    }
}
