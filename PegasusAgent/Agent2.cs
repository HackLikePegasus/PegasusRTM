using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace PegasusRTM.PegasusAgent
{

    public enum ResultType
    {
        Security,
        Performance,
        UserExperience,
        SomeThingElse
    }


    public partial class Agent
    {
        public SearchLogResult SearchSpecificLog(StreamReader reader, List<string> keywords, ResultType resType)
        {
            StreamWriter writer = null;
            List<string> matchedKeyWords= new List<string>();
            IEnumerable<string> currentMatchedKeyWords;
            StringBuilder line = new StringBuilder(string.Empty);
            if (reader != null)
            {
                while (true)
                {
                    if (!reader.EndOfStream)
                    {
                        line.Append(reader.ReadLine());
                        currentMatchedKeyWords = keywords.Where(t => line.ToString().Contains(t)); //Need to place porter stemming Algorithm 
                        if (currentMatchedKeyWords != null)
                        {   
                            matchedKeyWords.AddRange(currentMatchedKeyWords);
                            writer.WriteLine(line.ToString());
                        }
                    }
                    else break;
                }
                return new SearchLogResult {
                    resultType = resType,
                    IsKeywordFound = matchedKeyWords.Count >0 ? true : false,
                    FoundKeywords = matchedKeyWords,
                    Writer = writer
                };
            }
            else
            {
                Console.WriteLine("No Stream available");
                return new SearchLogResult
                {
                    resultType = resType,
                    IsKeywordFound = false
                };
            }
        }
    }

    public class SearchLogResult
    {
        public ResultType resultType { set; get; }
        public bool IsKeywordFound { get; set; }
        public List<string> FoundKeywords { get; set; }
        public StreamWriter Writer { get; set; }
    }

}
