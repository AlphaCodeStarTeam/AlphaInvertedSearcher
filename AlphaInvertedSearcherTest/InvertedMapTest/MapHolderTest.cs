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
        private MapHolder _mapHolder = new MapHolder();
        
        [Fact]
        private void AddDocToMapTest()
        {
            var supply = GetAddDocToMapTestSupply();
            
            foreach (string fileName in supply.Item1)
            {
                _mapHolder.AddDoc(fileName, GetFileContextByName(fileName));
            }
            
            Assert.Equal(supply.Item2, _mapHolder.InvertedMap);
        }

        private static Tuple<List<string>, Dictionary<string, HashSet<string>>> GetAddDocToMapTestSupply()
        {
            List<string> fileNames = new List<string>()
            {
                "1.txt",
                "2.txt",
                "3.txt"
            };
            
            Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>()
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
            
            return new Tuple<List<string>, Dictionary<string, HashSet<string>>>(fileNames, dictionary);
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


        [Fact]
        private void RemoveDocFromMapTest()
        {
            
        }
        
    }
}