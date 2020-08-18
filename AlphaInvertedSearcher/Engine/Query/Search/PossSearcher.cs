namespace AlphaInvertedSearcher.Engine.Query
{
    public abstract class PossSearcher : Searcher
    {
        public override void Search(ResultSet resultSet, MapExtractor mapExtractor)
        {
            base.Search(resultSet, mapExtractor);
            ModifyResultForPoss(resultSet, mapExtractor);
            
        }
        
        private void ModifyResultForPoss(ResultSet resultSet, MapExtractor mapExtractor) {
            foreach (string word in resultSet.Query.poss) {
                resultSet.Result.UnionWith(mapExtractor.GetDocsByKeyword(word));
            }
        }
    }
}