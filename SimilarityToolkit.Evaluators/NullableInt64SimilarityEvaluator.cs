using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class NullableInt64SimilarityEvaluator : SimilarityEvaluator<long?>
    {
        public override double EvaluateDistance(long? item1, long? item2)
        {
            return Math.Abs((item1 ?? 0) - (item2 ?? 0));
        }
    }
}
