namespace SimilarityToolkit.Evaluators.Abstractions
{
    public interface ISimilarityEvaluator<T1, T2>
    {
        double EvaluateDistance(T1 item1, T2 item2);
    }
}
