using System;
using System.Collections.Generic;
using System.Linq;
using AlphaInvertedSearcher.InvertedMap;

namespace AlphaInvertedSearcher.Engine
{
    public class MapExtractor
    {
        private MapHolder _holder = new MapHolder();

        public virtual string GetDocById(string docId)
        {
            if (_holder.Docs.ContainsKey(docId))
            {
                return _holder.Docs[docId];
            }
            
            throw new DocumentNotFoundException();
        }
        
        public class DocumentNotFoundException : Exception
        {
            public override string Message { get; } = "You Haven't Added Document With Such Name Yet";
        }
        
        private List<string> GetDocsByKeyword(string keyword)
        {
            if(_holder.InvertedMap.ContainsKey(keyword))
                return _holder.InvertedMap[keyword].ToList();
            return new List<string>();
        }
    }
}