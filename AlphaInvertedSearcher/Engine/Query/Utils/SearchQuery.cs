using System.Collections.Generic;

namespace AlphaInvertedSearcher.Engine.Query
{
    public class SearchQuery : IClone<SearchQuery>
    {
        public HashSet<string> norms { get; } = new HashSet<string>();
        public HashSet<string> poss { get; } = new HashSet<string>();
        public HashSet<string> negs { get; } = new HashSet<string>();

        public SearchQuery()
        {
        }

        public SearchQuery Clone()
        {
            SearchQuery query = new SearchQuery();
            query.norms.UnionWith( norms);
            query.poss.UnionWith(poss);
            query.negs.UnionWith(negs);
            return query;
        }
    }
}