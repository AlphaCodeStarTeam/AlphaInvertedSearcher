using System;
using System.Collections.Generic;
using System.Linq;
using AlphaInvertedSearcher.Engine.Query;
using AlphaInvertedSearcher.InvertedMap;

namespace AlphaInvertedSearcher.Engine
{
    public class AlphaEngine : IClone<AlphaEngine>, IDecorate
    {
        protected IDecorate _decorate;
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

        protected AlphaEngine(IDecorate decorate)
        {
            _decorate = decorate;
        }

        public virtual string GetDocByID(string docID)
        {
            return _mapExtractor.GetDocById(docID);
        }

        public AlphaEngine AddMustIncludes(params string[] norms)
        {
            AlphaEngine alphaEngine = Clone();
            alphaEngine._query.norms.UnionWith(ArrayToLowerHashSet(norms));
            return alphaEngine;
        }

        public AlphaEngine AddLeastIncludes(params string[] poss)
        {
            AlphaEngine alphaEngine = Clone();
            alphaEngine._query.poss.UnionWith(ArrayToLowerHashSet(poss));
            return alphaEngine;
        }

        public AlphaEngine AddExcludes(params string[] negs)
        {
            AlphaEngine alphaEngine = Clone();
            alphaEngine._query.negs.UnionWith(ArrayToLowerHashSet(negs));
            return alphaEngine;
        }
        
        public AlphaEngine ReconstructMap(Map map)
        {
            AlphaEngine alphaEngine = Clone();
            alphaEngine._mapExtractor = new MapExtractor(map);
            return alphaEngine;
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