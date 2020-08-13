using System;
using System.Collections.Generic;
using System.IO;
using AlphaInvertedSearcher.InvertedMap;
using Xunit;

namespace AlphaInvertedSearcherTest.InvertedMapTest
{
    public class MapHolderTest
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
        
        private MapHolder _mapHolder = new MapHolder();
        
        [Fact]
        public void AddDocToMapTest()
        {
            InitMapper();
            Assert.Equal(GetAddDocToMapTestSupply(), _mapHolder.InvertedMap);
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
            InitMapper();
            dynamic supply = new
            {
                Item1 = _mapHolder.Docs, Item2 =  _mapHolder.InvertedMap
            };
            Assert.False(_mapHolder.RemoveAllDocs("Baby", "hmm"));
            Assert.Equal(supply.Item1, _mapHolder.Docs);
            Assert.Equal(supply.Item2, _mapHolder.InvertedMap);
            supply = RemoveDocsFromMapTestSupply();
            Assert.True(_mapHolder.RemoveAllDocs("1.txt", "2.txt"));
            Assert.Equal(supply.Item1, _mapHolder.Docs);
            Assert.Equal(supply.Item2, _mapHolder.InvertedMap);
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
        
        private void InitMapper()
        {
            foreach (string fileName in GetFileNames())
            {
                _mapHolder.AddDoc(fileName, GetFileContextByName(fileName));
            }
        }
        
    }
}