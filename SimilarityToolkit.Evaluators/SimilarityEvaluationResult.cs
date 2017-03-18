namespace SimilarityToolkit.Evaluators
{
    public sealed class SimilarityEvaluationResult<T>
    {
        public SimilarityEvaluationResult(T item1, T item2, decimal distance)
        {
            Item1 = item1;
            Item2 = item2;
            Distance = distance;
        }

        public decimal Distance { get; private set; }

        public T Item1 { get; private set; }

        public T Item2 { get; private set; }
    }
}
