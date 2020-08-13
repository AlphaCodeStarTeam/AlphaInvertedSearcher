using System.Collections.Generic;

namespace AlphaInvertedSearcher.Engine.Query
{
    public class ResultSet : HashSet<string>
    {
        private AlphaSearcher _alphaSearcher;

        public HashSet<string> ExecuteQuery(SearchQuery query)
        {
            _alphaSearcher.Search(query, this);
            return this;
        }
    }
}