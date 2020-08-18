using System.Collections.Generic;

namespace AlphaInvertedSearcher.Engine.Query
{
    public class ResultSet
    {
        public HashSet<string> Result { get; set; }
        public SearchQuery Query { get; set; }
        public MapExtractor MapExtractor { get; }

        private ISearch _searcher = new NegsSearcher();

        public ResultSet(MapExtractor mapExtractor)
        {
            MapExtractor = mapExtractor;
            
        }

        public HashSet<string> ExecuteQuery(SearchQuery query)
        {
            Query = query;
            Result = new HashSet<string>();
            _searcher.Search(this, MapExtractor);
            return Result;
        }
    }
}