using System;

namespace SimilarityToolkit.Evaluators.Abstractions
{
    public abstract class SimilarityEvaluator
    {
        public abstract double EvaluateDistance(object item1, object item2);

        public abstract Type EvaluatedType { get; }
    }
}
