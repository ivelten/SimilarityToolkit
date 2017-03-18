using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class DateTimeSimilarityEvaluator : SimilarityEvaluator<DateTime>
    {
        public override decimal EvaluateDistance(DateTime item1, DateTime item2)
        {
            if (item1.Date == item1 && item2.Date == item2)
                return Math.Abs((item1 - item2).Days);

            return Math.Abs((item1 - item2).Seconds);
        }
    }
}
