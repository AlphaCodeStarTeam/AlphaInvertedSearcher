using System.Collections.Generic;

namespace AlphaInvertedSearcher.Engine.Query
{
    public abstract class Searcher
    {
        protected MapExtractor _mapExtractor;

        protected Searcher(MapExtractor mapExtractor)
        {
            _mapExtractor = mapExtractor;
        }

        public abstract void Search(SearchQuery query, HashSet<string> resultSet);

    }
}