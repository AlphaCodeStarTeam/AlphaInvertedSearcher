using System.Collections.Generic;
using System.Linq;

namespace AlphaInvertedSearcher.InvertedMap.Utils
{
    public class WordBuilder : ContextBuilder<HashSet<string>>
    { 
        private readonly char[] splitters = new[] {' ', '\n', '\t', ((char)11), ((char)12), ((char)13)};
        
        public WordBuilder(string supply) : base(supply) { }

        protected override HashSet<string> ConsumeContext()
        {
            HashSet<string> words = Supply.Split(splitters).ToHashSet();
            words.RemoveWhere(s => s.Length == 1 && splitters.Contains(s[0]));
            words.Remove("");
            return words;
        }
    }
}