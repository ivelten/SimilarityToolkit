using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class Int64SimilarityEvaluator : ISimilarityEvaluator<long>, ISimilarityEvaluator<long?>
    {
        public double EvaluateDistance(long? item1, long? item2)
        {
            return Math.Abs(item1 ?? 0 - item2 ?? 0);
        }

        public double EvaluateDistance(long item1, long item2)
        {
            return Math.Abs(item1 - item2);
        }
    }
}
