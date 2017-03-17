using SimilarityToolkit.Evaluators.Abstractions;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class DoubleSimilarityEvaluator : ISimilarityEvaluator<double, double>
    {
        public double EvaluateDistance(double item1, double item2)
        {
            return Math.Abs(item1 - item2);
        }
    }
}
