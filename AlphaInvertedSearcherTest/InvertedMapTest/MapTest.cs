using System;
using System.Collections.Generic;
using System.IO;
using AlphaInvertedSearcher.InvertedMap;
using Xunit;

namespace AlphaInvertedSearcherTest.InvertedMapTest
{
    public class MapTest
    {
        private static readonly string DocsDirectory = "InvertedMapTest\\TestDocs\\";
        private static List<string> GetFileNames()
        {
            return new List<string>()
            {
                "1.txt",
                "2.txt",
                "3.txt"
            };
        }
        
        private static string GetFileContextByName(string fileName)
        {
            return File.ReadAllText(GetTestDir() + DocsDirectory + fileName);
        }
        
        private static string GetTestDir()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            for (int i = 0; i < 3; i++)
            {
                path = Path.GetDirectoryName(path);
            }

            return path + "\\";
        }
        
        public static Map InitMapper()
        {
            Map map = new Map();
            foreach (string fileName in GetFileNames())
            {
                map.AddDoc(fileName, GetFileContextByName(fileName));
            }

            return map;
        }
        
        private Map _map = new Map();
        
        [Fact]
        public void AddDocToMapTest()
        {
            _map = InitMapper();
            Assert.Equal(GetAddDocToMapTestSupply(), _map.InvertedMap);
        }

        private Dictionary<string, HashSet<string>> GetAddDocToMapTestSupply()
        {
            return new Dictionary<string, HashSet<string>>()
            {
                {"the", new HashSet<string>() {"1.txt", "2.txt"}},
                {"a", new HashSet<string>() {"1.txt", "2.txt", "3.txt"}},
                {"witcher", new HashSet<string>() {"1.txt", "2.txt"}},
                {"is", new HashSet<string>() {"1.txt", "3.txt"}},
                {"role-playing", new HashSet<string>() {"1.txt", "3.txt"}},
                {"geralt", new HashSet<string>() {"2.txt"}},
                {"hunter", new HashSet<string>() {"2.txt", "3.txt"}},
                {"anya", new HashSet<string>() {"3.txt"}},
            };
        }


        [Fact]
        public void RemoveDocsFromMapTest()
        {
            _map = InitMapper();
            dynamic supply = new
            {
                Item1 = _map.Docs, Item2 =  _map.InvertedMap
            };
            Assert.False(_map.RemoveAllDocs("Baby", "hmm"));
            Assert.Equal(supply.Item1, _map.Docs);
            Assert.Equal(supply.Item2, _map.InvertedMap);
            supply = RemoveDocsFromMapTestSupply();
            Assert.True(_map.RemoveAllDocs("1.txt", "2.txt"));
            Assert.Equal(supply.Item1, _map.Docs);
            Assert.Equal(supply.Item2, _map.InvertedMap);
        }


        private  Tuple<Dictionary<string, string>, Dictionary<string, HashSet<string>>>RemoveDocsFromMapTestSupply()
        {
            return new Tuple<Dictionary<string, string>, Dictionary<string, HashSet<string>>>(
                new Dictionary<string, string>()
                {
                    {"3.txt", "Anya is a role-playing HUNTER"}
                }
                , 
                new Dictionary<string, HashSet<string>>()
                    {
                    {"anya", new HashSet<string>() {"3.txt"}},
                    {"is", new HashSet<string>() {"3.txt"}},
                    {"a", new HashSet<string>() {"3.txt"}},
                    {"role-playing", new HashSet<string>() {"3.txt"}},
                    {"hunter", new HashSet<string>() {"3.txt"}}
                    }
                );
        }
        
    }
}