using System.Collections.Generic;
using System.Linq;
using AlphaInvertedSearcher.InvertedMap.Utils;

namespace AlphaInvertedSearcher.InvertedMap
{
    public class MapHolder
    {
        public Dictionary<string, HashSet<string>> InvertedMap { get; }
        private IBuild<string, HashSet<string>> wordBuilder;

        public MapHolder()
        {
            InvertedMap = new Dictionary<string, HashSet<string>>();
        }

        public void AddDocToMap(string docId, string docContext)
        {
            wordBuilder = new WordBuilder(docContext);
            HashSet<string> docKeywords = wordBuilder.Build();
            foreach (var keyword in docKeywords)
            {
                AddKeyToMap(keyword, docId);
            }
        }

        private void AddKeyToMap(string keyword, string docId)
        {
            if(InvertedMap.ContainsKey(keyword))
                InvertedMap[keyword].Add(docId);
            else
                InvertedMap.Add(keyword,  new HashSet<string>() {docId});
        }
    }
}