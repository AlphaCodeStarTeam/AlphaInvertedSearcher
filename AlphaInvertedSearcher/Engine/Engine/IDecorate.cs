using System.Collections.Generic;

namespace AlphaInvertedSearcher.Engine
{
    public interface IDecorate
    {
        string GetDocByID(string docID);

        List<string> ExecuteQuery();
    }
}