namespace SimilarityToolkit
{
    internal class ReferenceWrapper<T>
    {
        public ReferenceWrapper(T item)
        {
            Item = item;
        }

        public ReferenceWrapper()
        {
        }

        public T Item { get; set; }
    }
}
