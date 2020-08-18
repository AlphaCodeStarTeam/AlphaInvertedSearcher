namespace AlphaInvertedSearcher.Engine.Query
{
    public interface ISearch
    {
        void Search(ResultSet resultSet, MapExtractor mapExtractor);
    }
}