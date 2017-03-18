using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class NullableDateTimeSimilarityEvaluator : SimilarityEvaluator<DateTime?>
    {
        public override decimal EvaluateDistance(DateTime? item1, DateTime? item2)
        {
            if (!item1.HasValue)
                item1 = DateTime.MinValue;

            if (!item2.HasValue)
                item2 = DateTime.MinValue;

            if (item1.Value.Date == item1 && item2.Value.Date == item2)
                return Math.Abs((item1.Value - item2.Value).Days);

            return Math.Abs((item1.Value - item2.Value).Seconds);
        }
    }
}
