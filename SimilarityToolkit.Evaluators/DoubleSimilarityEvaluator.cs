using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class DoubleSimilarityEvaluator : ISimilarityEvaluator<double>, ISimilarityEvaluator<double?>
    {
        public double EvaluateDistance(double? item1, double? item2)
        {
            return Math.Abs(item1 ?? 0.0 - item2 ?? 0.0);
        }

        public double EvaluateDistance(double item1, double item2)
        {
            return Math.Abs(item1 - item2);
        }
    }
}
