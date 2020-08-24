using System.Linq;
using AlphaApplication.Model;
using AlphaInvertedSearcher.InvertedMap;
using Xunit;

namespace AlphaApplicationTest.ModelTest
{
    public class FileReaderTest
    {
        [Fact]
        public void InitMapTest()
        {
            Map map = FileReader.GetMap();
            Assert.Equal(1000, map.Docs.Count);
            Assert.True(map.Docs.ContainsKey("57110"));
        }
    }
}