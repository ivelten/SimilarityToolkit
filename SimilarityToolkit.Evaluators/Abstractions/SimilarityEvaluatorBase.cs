using System;

namespace SimilarityToolkit.Evaluators.Abstractions
{
    public abstract class SimilarityEvaluatorBase
    {
        internal abstract decimal EvaluateDistance(object item1, object item2);

        internal abstract Type EvaluatedType { get; }
    }
}
