using System.Collections.Generic;
using AlphaInvertedSearcher.Engine;
using AlphaInvertedSearcherTest.InvertedMapTest;
using Xunit;

namespace AlphaInvertedSearcherTest.EngineTest.DecoratorTest
{
    public class DecorTest
    {
        private AlphaEngineBuilder _engineBuilder = new AlphaEngineBuilder();
        [Fact]
        public void EngineBuilderTest1()
        {
            var alphaEngine = _engineBuilder.Create(MapTest.InitMapper());
            Assert.Equal("The Witcher is a role-playing", alphaEngine.GetDocByID("1.txt"));
            var resultSet = alphaEngine.AddMustIncludes("Witcher").AddMustIncludes("WiTchEr", "is").AddLeastIncludes("AnyA")
                .AddExcludes("role-playing").ExecuteQuery();
            Assert.Equal(new List<string>(), resultSet);
        }

        [Fact]
        public void EngineBuilderTest2()
        {
            var alphaEngine = _engineBuilder.SetSummarizedDoc(2).Create(MapTest.InitMapper());
            Assert.NotEqual("The Witcher is a role-playing", alphaEngine.GetDocByID("1.txt"));
            Assert.Equal("1.txt Summery: \nThe Witcher...", alphaEngine.GetDocByID("1.txt"));
            var resultSet = alphaEngine.AddMustIncludes("Witcher").AddMustIncludes("WiTchEr", "is").AddLeastIncludes("AnyA")
                .AddExcludes("role-playing").ExecuteQuery();
            Assert.Equal(new List<string>(), resultSet);
        }

        [Fact]
        public void EngineBuilderTest3()
        {
            var alphaEngine = _engineBuilder.SetPrettyQuery(1).Create(MapTest.InitMapper());
            Assert.Equal("The Witcher is a role-playing", alphaEngine.GetDocByID("1.txt"));
            var resultSet = alphaEngine.AddLeastIncludes("WitCHER", "aNyA").ExecuteQuery();
            Assert.Equal(new List<string>()
            {
                "3 Case(s) Found As Follows:", "\tDoc1: 1.txt", "\t\t.\n\t\t.\n\t\t.", "\tDoc3: 3.txt"
            }, resultSet);
        }

        [Fact]
        public void EngineBuilderTest4()
        {
            var alphaEngine = _engineBuilder.SetPrettyQuery(1).SetSummarizedDoc(2).Create(MapTest.InitMapper());
            Assert.Equal("1.txt Summery: \nThe Witcher...", alphaEngine.GetDocByID("1.txt"));
            var resultSet = alphaEngine.AddLeastIncludes("WitCHER", "aNyA").ExecuteQuery();
            Assert.Equal(new List<string>()
            {
                "3 Case(s) Found As Follows:", "\tDoc1: 1.txt", "\t\t.\n\t\t.\n\t\t.", "\tDoc3: 3.txt"
            }, resultSet);
        }

        [Fact]
        public void EngineBuilderTest5()
        {
            var alphaEngine = _engineBuilder.SetPrettyQuery(2).Create(MapTest.InitMapper());
            var resultSet = alphaEngine.AddMustIncludes("Witcher").AddMustIncludes("WiTchEr", "is").AddLeastIncludes("AnyA")
                .AddExcludes("role-playing").ExecuteQuery();
            Assert.Equal(new List<string>()
            {
                "No Result Found"
            }, resultSet);
            resultSet = alphaEngine.AddLeastIncludes("WitCHER", "aNyA").ExecuteQuery();
            Assert.Equal(new List<string>(){
                "3 Case(s) Found As Follows:", "\tDoc1: 1.txt", "\tDoc2: 2.txt", "\tDoc3: 3.txt"
            }, resultSet);
        }
    }
}