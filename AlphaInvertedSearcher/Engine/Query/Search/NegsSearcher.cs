namespace AlphaInvertedSearcher.Engine.Query
{
    public class NegsSearcher : PossSearcher
    {
        public override void Search(ResultSet resultSet, MapExtractor mapExtractor)
        {
            base.Search(resultSet, mapExtractor);
            ModifyResultForNegs(resultSet, mapExtractor);
            
        }
        
        private void ModifyResultForNegs(ResultSet resultSet, MapExtractor mapExtractor) {
            foreach (string keyword in resultSet.Query.negs)
            {
                foreach (string docId in mapExtractor.GetDocsByKeyword(keyword))
                {
                    resultSet.Result.Remove(docId);
                }
            }
        }
    }
}