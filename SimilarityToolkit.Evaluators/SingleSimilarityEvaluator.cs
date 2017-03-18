using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class SingleSimilarityEvaluator : SimilarityEvaluator<float>
    {
        public override decimal EvaluateDistance(float item1, float item2)
        {
            return Math.Abs((decimal)item1 - (decimal)item2);
        }
    }
}
