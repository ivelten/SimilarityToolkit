using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class NullableDoubleSimilarityEvaluator : SimilarityEvaluatorBase<double?>
    {
        public override decimal EvaluateDistance(double? item1, double? item2)
        {
            return Math.Abs((decimal)(item1 ?? 0.0) - (decimal)(item2 ?? 0.0));
        }
    }
}
