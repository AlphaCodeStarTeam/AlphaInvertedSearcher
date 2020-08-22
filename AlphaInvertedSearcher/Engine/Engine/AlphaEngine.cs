using System;
using System.Collections.Generic;
using System.Linq;
using AlphaInvertedSearcher.Engine.Query;
using AlphaInvertedSearcher.InvertedMap;

namespace AlphaInvertedSearcher.Engine
{
    public class AlphaEngine : IClone<AlphaEngine>
    {
        protected AlphaEngine _decorate;
        private MapExtractor _mapExtractor;
        private SearchQuery _query;

        private AlphaEngine()
        {
        }

        public AlphaEngine(Map map)
        {
            _mapExtractor = new MapExtractor(map);
            _query = new SearchQuery();
            _decorate = null;
        }

        protected AlphaEngine(AlphaEngine decorate)
        {
            _decorate = decorate;
        }

        protected virtual AlphaEngine CreateThisEngine(AlphaEngine decorate) => new AlphaEngine(decorate);

        public virtual string GetDocByID(string docID)
        {
            return _mapExtractor.GetDocById(docID);
        }

        public AlphaEngine AddMustIncludes(params string[] norms)
        {
            if (_decorate == null)
            {
                AlphaEngine alphaEngine = Clone();
                alphaEngine._query.norms.UnionWith(ArrayToLowerHashSet(norms));
                return alphaEngine;
            }
            
            return CreateThisEngine(_decorate.AddMustIncludes(norms));
        }

        public AlphaEngine AddLeastIncludes(params string[] poss)
        {
            if (_decorate == null)
            {
                AlphaEngine alphaEngine = Clone();
                alphaEngine._query.poss.UnionWith(ArrayToLowerHashSet(poss));
                return alphaEngine; 
            }
            
            return CreateThisEngine(_decorate.AddLeastIncludes(poss));
        }

        public AlphaEngine AddExcludes(params string[] negs)
        {
            if (_decorate == null)
            {
                AlphaEngine alphaEngine = Clone();
                alphaEngine._query.negs.UnionWith(ArrayToLowerHashSet(negs));
                return alphaEngine;  
            }

            return CreateThisEngine(_decorate.AddExcludes(negs));
        }
        
        public AlphaEngine ReconstructMap(Map map)
        {
            if (_decorate == null)
            {
                AlphaEngine alphaEngine = Clone();
                alphaEngine._mapExtractor = new MapExtractor(map);
                return alphaEngine;
            }

            return CreateThisEngine(_decorate.ReconstructMap(map));
        }

        public virtual List<string> ExecuteQuery()
        {
            var result = new ResultSet(_mapExtractor, _query).ExecuteQuery().ToList();
            _query = new SearchQuery();
            return result;
        }

        private HashSet<string> ArrayToLowerHashSet(string[] strings)
        {
            var stringsHashSet = new HashSet<string>();
            foreach (var str in strings)
            {
                stringsHashSet.Add(str.ToLower());
            }

            return stringsHashSet;
        }
        
        public AlphaEngine Clone()
        {
            AlphaEngine alphaEngine = new AlphaEngine();
            alphaEngine._mapExtractor = _mapExtractor.Clone();
            alphaEngine._query = _query.Clone();
            return alphaEngine;
        }
        
    }

}