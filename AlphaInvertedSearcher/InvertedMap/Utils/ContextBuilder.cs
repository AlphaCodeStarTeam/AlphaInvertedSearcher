using System;
using System.Collections.Generic;

namespace AlphaInvertedSearcher.InvertedMap.Utils
{
    public abstract class ContextBuilder <E> : IBuild<string,E>
    {
        
        public string Supply { get; set; }

        protected ContextBuilder(string supply)
        {
            Supply = supply;
        }

        public E Build()
        {
            return ConsumeContext();
        }

        protected abstract E ConsumeContext();
    }
}