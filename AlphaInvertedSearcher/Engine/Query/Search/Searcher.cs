using System.Collections.Generic;

namespace AlphaInvertedSearcher.Engine.Query
{
    public abstract class Searcher : ISearch
    {

        private void ModifyResultForNorms(ResultSet resultSet, MapExtractor mapExtractor) {
            foreach (string norm in resultSet.Query.norms)
                resultSet.Result.UnionWith(mapExtractor.GetDocsByKeyword(norm));

            foreach (var docId in GetAndPrimedSet(resultSet, mapExtractor))
                resultSet.Result.Remove(docId);
        }

        private HashSet<string> GetAndPrimedSet(ResultSet resultSet, MapExtractor mapExtractor) {
            HashSet<string> hashSetPrime = new HashSet<string>();
            foreach (string norm in resultSet.Query.norms)  {
                HashSet<string> hashSet = new HashSet<string>(resultSet.Result);
                foreach (var docId in mapExtractor.GetDocsByKeyword(norm))
                    hashSet.Remove(docId);
                hashSetPrime.UnionWith(hashSet);
            }
            return hashSetPrime;
        }

        public virtual void Search(ResultSet resultSet, MapExtractor mapExtractor)
        {
            ModifyResultForNorms(resultSet, mapExtractor);
        }
    }
}