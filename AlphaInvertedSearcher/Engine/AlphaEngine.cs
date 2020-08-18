using System.Collections.Generic;
using System.Linq;
using AlphaInvertedSearcher.Engine.Query;
using AlphaInvertedSearcher.InvertedMap;

namespace AlphaInvertedSearcher.Engine
{
    public class AlphaEngine
    {
        private MapExtractor _mapExtractor;
        private ResultSet _resultSet;
        private SearchQuery _query;

        public AlphaEngine(Map map)
        {
            _mapExtractor = new MapExtractor(map);
            _resultSet = new ResultSet(this._mapExtractor);
            _query = new SearchQuery();
        }

        public virtual string GetDocByID(string docID)
        {
            return _mapExtractor.GetDocById(docID);
        }

        public AlphaEngine AddNorms(params string[] norms)
        {
            AlphaEngine alphaEngine = Cloner.DeepClone(this);
            alphaEngine._query.norms.UnionWith(norms);
            return alphaEngine;
        }

        public AlphaEngine AddPoss(params string[] poss)
        {
            AlphaEngine alphaEngine = Cloner.DeepClone(this);
            alphaEngine._query.poss.UnionWith(poss);
            return alphaEngine;
        }

        public AlphaEngine AddNegs(params string[] negs)
        {
            AlphaEngine alphaEngine = Cloner.DeepClone(this);
            alphaEngine._query.negs.UnionWith(negs);
            return alphaEngine;
        }
        
        public AlphaEngine ReconstructMap(Map map)
        {
            AlphaEngine alphaEngine = Cloner.DeepClone(this);
            alphaEngine._mapExtractor = new MapExtractor(map);
            return alphaEngine;
        }

        public List<string> ExecuteQuery()
        {
            var result = _resultSet.ExecuteQuery(_query).ToList();
            _resultSet = new ResultSet(_mapExtractor);
            _query = new SearchQuery();
            return result;
        }
        
        

    }
    

    
}