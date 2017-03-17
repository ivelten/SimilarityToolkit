namespace SimilarityToolkit.Evaluators.Abstractions.Generic
{
    public interface ISimilarityEvaluator<T>
    {
        double EvaluateDistance(T item1, T item2);
    }
}
