namespace SimilarityToolkit.Evaluators.Abstractions
{
    public interface ISimilarityEvaluator<T>
    {
        double EvaluateDistance(T item1, T item2);
    }
}
