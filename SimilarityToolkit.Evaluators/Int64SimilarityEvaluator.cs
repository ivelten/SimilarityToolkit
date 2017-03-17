using SimilarityToolkit.Evaluators.Abstractions;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class Int64SimilarityEvaluator : ISimilarityEvaluator<long, long>, ISimilarityEvaluator<long?, long?>
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
