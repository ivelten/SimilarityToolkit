using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class DoubleSimilarityEvaluator : SimilarityEvaluator<double>
    {
        public override decimal EvaluateDistance(double item1, double item2)
        {
            return Math.Abs((decimal)item1 - (decimal)item2);
        }
    }
}
