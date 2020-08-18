using System.Collections.Generic;

namespace AlphaInvertedSearcher.Engine.Query
{
    public class ResultSet
    {
        public HashSet<string> Result { get; } = new HashSet<string>();
        public SearchQuery Query { get; }
        public MapExtractor MapExtractor { get; }

        private ISearch _searcher = new NegsSearcher();

        public ResultSet(MapExtractor mapExtractor, SearchQuery query)
        {
            MapExtractor = mapExtractor;
            Query = query;
        }

        public HashSet<string> ExecuteQuery()
        {
            _searcher.Search(this, MapExtractor);
            return Result;
        }
    }
}