namespace AlphaInvertedSearcher.InvertedMap.Utils
{
    public interface IBuild<E, T>
    {
        public E Supply { get; set; }

        public T Build();
    }
}