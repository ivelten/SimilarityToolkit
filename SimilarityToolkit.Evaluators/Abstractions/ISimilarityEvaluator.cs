using System;

namespace SimilarityToolkit.Evaluators.Abstractions
{
    public interface ISimilarityEvaluator
    {
        double EvaluateDistance(object item1, object item2);

        Type EvaluatedType { get; }
    }
}
