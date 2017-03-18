using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class DecimalSimilarityEvaluator : SimilarityEvaluator<decimal>
    {
        public override decimal EvaluateDistance(decimal item1, decimal item2)
        {
            return Math.Abs(item1 - item2);
        }
    }
}
