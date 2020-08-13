using System.Collections.Generic;

namespace AlphaInvertedSearcher.Engine.Query
{
    public class SearchQuery
    {
        public HashSet<string> norms { get; set; } = new HashSet<string>();
        public HashSet<string> poss { get; set; } = new HashSet<string>();
        public HashSet<string> negs { get; set; } = new HashSet<string>();

        public SearchQuery()
        {
        }
        
    }
}