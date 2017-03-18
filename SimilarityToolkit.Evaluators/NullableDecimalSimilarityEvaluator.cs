using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class NullableDecimalSimilarityEvaluator : SimilarityEvaluator<decimal?>
    {
        public override decimal EvaluateDistance(decimal? item1, decimal? item2)
        {
            return Math.Abs((item1 ?? 0) - (item2 ?? 0));
        }
    }
}
