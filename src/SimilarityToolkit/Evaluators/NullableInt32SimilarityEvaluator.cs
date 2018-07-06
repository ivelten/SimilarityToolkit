using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class NullableInt32SimilarityEvaluator : SimilarityEvaluatorBase<int?>
    {
        public override decimal EvaluateDistance(int? item1, int? item2)
        {
            return Math.Abs((item1 ?? 0) - (item2 ?? 0));
        }
    }
}
