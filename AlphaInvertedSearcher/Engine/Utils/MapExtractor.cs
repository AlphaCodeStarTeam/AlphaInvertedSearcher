using System;
using System.Collections.Generic;
using System.Linq;
using AlphaInvertedSearcher.InvertedMap;

namespace AlphaInvertedSearcher.Engine
{
    public class MapExtractor : IClone<MapExtractor>
    {
        private Map _map;

        public MapExtractor(Map map)
        {
            _map = map;
        }

        public string GetDocById(string docId)
        {
            if (_map.Docs.ContainsKey(docId))
            {
                return _map.Docs[docId];
            }
            
            throw new DocumentNotFoundException();
        }

        public List<string> GetDocsByKeyword(string keyword)
        {
            if(_map.InvertedMap.ContainsKey(keyword))
                return _map.InvertedMap[keyword].ToList();
            return new List<string>();
        }

        public MapExtractor Clone()
        {
            return new MapExtractor(_map);
        }
    }
    
    public class DocumentNotFoundException : Exception
    {
        public override string Message { get; } = "You Haven't Added Document With Such Name Yet";
    }
    
}