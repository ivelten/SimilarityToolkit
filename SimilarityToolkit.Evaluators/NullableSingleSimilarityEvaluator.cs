using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class NullableSingleSimilarityEvaluator : SimilarityEvaluatorBase<float?>
    {
        public override decimal EvaluateDistance(float? item1, float? item2)
        {
            return Math.Abs((decimal)(item1 ?? 0) - (decimal)(item2 ?? 0));
        }
    }
}
