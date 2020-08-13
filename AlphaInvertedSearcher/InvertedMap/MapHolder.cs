using System.Collections.Generic;
using System.Linq;
using AlphaInvertedSearcher.InvertedMap.Utils;

namespace AlphaInvertedSearcher.InvertedMap
{
    public class MapHolder
    {
        public Dictionary<string, HashSet<string>> InvertedMap { get; } = new Dictionary<string, HashSet<string>>();
        public Dictionary<string, string> Docs { get; } = new Dictionary<string, string>();
        
        private IBuild<string, HashSet<string>> wordBuilder;

        public bool AddDoc(string docId, string docContext)
        {
            bool contains = Docs.ContainsKey(docId);
            
            Docs.Add(docId, docContext);
            wordBuilder = new WordBuilder(docContext);
            HashSet<string> docKeywords = wordBuilder.Build();
            foreach (var keyword in docKeywords)
            {
                AddKeyToMap(keyword.ToLower(), docId);
            }

            return contains;
        }

        private void AddKeyToMap(string keyword, string docId)
        {
            if(InvertedMap.ContainsKey(keyword))
                InvertedMap[keyword].Add(docId);
            else
                InvertedMap.Add(keyword,  new HashSet<string>() {docId});
        }

        public string RemoveDoc(string docID)
        {
            if (Docs.ContainsKey(docID))
            {
                string docContext = Docs[docID];
                Docs.Remove(docID);
                foreach (var keyword in InvertedMap.Keys)
                {
                    InvertedMap[keyword].Remove(docID);
                    if (InvertedMap[keyword].Count == 0)
                        InvertedMap.Remove(keyword);
                }
                return docContext;
            }
            return "";
        }

        public bool RemoveAllDocs(params string[] docIds)
        {
            var docIdsSet = docIds.ToHashSet();
            var containsAll = true;
            
            foreach (var docId in docIdsSet)
            {
                if (containsAll)
                    containsAll = Docs.ContainsKey(docId);
                RemoveDoc(docId);
            }

            return containsAll;
        }
    }
}