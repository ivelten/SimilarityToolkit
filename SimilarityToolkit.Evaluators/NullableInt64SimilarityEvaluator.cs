using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class NullableInt64SimilarityEvaluator : SimilarityEvaluatorBase<long?>
    {
        public override decimal EvaluateDistance(long? item1, long? item2)
        {
            return Math.Abs((item1 ?? 0) - (item2 ?? 0));
        }
    }
}
