using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AlphaInvertedSearcher.Engine.Query
{
    public class AlphaSearcher : Searcher
    {
        private List<Searcher> _searchers = new List<Searcher>();

        public AlphaSearcher(MapExtractor mapExtractor) : base(mapExtractor) { }

        public override void Search(SearchQuery query, HashSet<string> resultSet)
        {
            foreach (var searcher in _searchers)
            {
                searcher.Search(query, resultSet);
            }
        }
    }
}