using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class NullableDoubleSimilarityEvaluator : SimilarityEvaluator<double?>
    {
        public override double EvaluateDistance(double? item1, double? item2)
        {
            return Math.Abs((item1 ?? 0.0) - (item2 ?? 0.0));
        }
    }
}
