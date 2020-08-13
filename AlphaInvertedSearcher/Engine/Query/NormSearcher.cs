using System.Collections.Generic;

namespace AlphaInvertedSearcher.Engine.Query
{
    public class NormSearcher : Searcher
    {
        public NormSearcher(MapExtractor mapExtractor) : base(mapExtractor)
        {
        }
        
        public override void Search(SearchQuery query, HashSet<string> resultSet)
        {
            throw new System.NotImplementedException();
        }
        
        /*private void ModifyResultForNorms(HashSet<string> norms, HashSet<string> resultSet) {
            foreach (string norm in norms)
                resultSet.UnionWith(GetDocsByKeyword(norm));
            
            foreach (var docId in GetAndPrimedSet())
                resultSet.Remove(docId);
        }

        private HashSet<string> GetAndPrimedSet(HashSet<string> norms, HashSet<string> resultSet) {
            HashSet<string> hashSetPrime = new HashSet<string>();
            foreach (string norm in norms)  {
                HashSet<string> hashSet = new HashSet<string>(resultSet);
                foreach (var docId in GetDocsByKeyword(norm))
                    hashSet.Remove(docId);
                hashSetPrime.UnionWith(hashSet);
            }
            return hashSetPrime;
        }*/

    }
}