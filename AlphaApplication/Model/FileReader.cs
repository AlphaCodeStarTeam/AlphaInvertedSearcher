using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using AlphaInvertedSearcher.InvertedMap;

namespace AlphaApplication.Model
{
    public class FileReader
    {
        private static readonly string DATABASE_PATH = GetSlnDir() + "AlphaApplication\\Model\\Database\\";

        public static Map GetMap()
        {
            Map map = new Map();
            Directory.GetFiles(DATABASE_PATH).ToList().ForEach(docId => map.AddDoc(GetDocIdByPath(docId), File.ReadAllText(docId)));
            return map;
        }

        public static string GetDocIdByPath(string docPath) => docPath.Split("\\")[^1];
        
        private static string GetSlnDir()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            for (int i = 0; i < 4; i++)
            {
                path = Path.GetDirectoryName(path);
            }
            
            return path + "\\";
        }
        
    }
}