using System;

namespace SimilarityToolkit.Evaluators.Abstractions
{
    public abstract class SimilarityEvaluator
    {
        internal abstract double EvaluateDistance(object item1, object item2);

        internal abstract Type EvaluatedType { get; }
    }
}
