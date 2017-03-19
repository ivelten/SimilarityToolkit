namespace SimilarityToolkit
{
    internal class EvaluationSet<T>
    {
        public EvaluationSet(ReferenceWrapper<T> item1, ReferenceWrapper<T> item2, decimal distance)
        {
            Item1 = item1;
            Item2 = item2;
            Distance = distance;
        }

        public EvaluationSet()
        {
        }

        public ReferenceWrapper<T> Item1 { get; set; }

        public ReferenceWrapper<T> Item2 { get; set; }

        public decimal Distance { get; set; }
    }
}
