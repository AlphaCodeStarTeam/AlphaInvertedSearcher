
using System.Collections.Generic;
using AlphaInvertedSearcher.InvertedMap.Utils;
using Xunit;

namespace AlphaInvertedSearcherTest.InvertedMapTest.Utils
{
    public class WordBuilderTest
    {
        private IBuild<string, HashSet<string>> wordBuilder;

        [Fact]
        public void TestRealities()
        {
            Assert.True("\f".Equals("" + ((char)12)));
            Assert.True("\v".Equals("" + ((char)11)));
            Assert.True("\r".Equals("" + ((char)13)));
        }
        
        [Theory]
        [MemberData(nameof(ConsumeContextTestSupplier))]
        public void ConsumeContextTest(string context, HashSet<string> expected)
        {
            wordBuilder = new WordBuilder(context);
            Assert.Equal(expected, wordBuilder.Build());
        }

        public static IEnumerable<object[]> ConsumeContextTestSupplier => new[]
        {
            new object[]
            {
                "A Plague Tale: Innocence is an action-adventure horror stealth game", 
                new HashSet<string>(){"A", "Plague", "Tale:", "Innocence", "is", "an", "action-adventure", "horror", "stealth", "game"}, 
            },
            new object[]
            {
                "Grand     Theft  Auto: San Andreas is a \n    2004 action-adventure game\t\tdeveloped by \n\n\n Rockstar North and published by    Rockstar   Games",
                new HashSet<string>(){"Grand", "Theft", "Auto:", "San", "Andreas", "is", "a", "2004", "action-adventure", "game", "developed", "by", "Rockstar", "North", "and", "published", "by", "Rockstar", "Games"},
            },
            new object[]
            {
                "    \t\n\n\t\tand the \t  \t \neleventh entry\n in the     Tomb\n Raider \t\t series   \t\t\t \n    ", 
                new HashSet<string>(){"and", "the", "eleventh", "entry", "in", "the", "Tomb", "Raider", "series"}, 
            },
            new object[]
            {
            "    \t\n\n\t\tand \f \r  \r the \t  \t \neleventh \f \ventry\n \v \v \fin the \f \v  \v   Tomb\n Raider \t\t series\r \f  \t\t\t \n    ", 
            new HashSet<string>(){"and", "the", "eleventh", "entry", "in", "the", "Tomb", "Raider", "series"}, 
            }
        };
    }
}