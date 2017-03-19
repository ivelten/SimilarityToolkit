using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class NullableInt16SimilarityEvaluator : SimilarityEvaluatorBase<short?>
    {
        public override decimal EvaluateDistance(short? item1, short? item2)
        {
            return Math.Abs((item1 ?? 0) - (item2 ?? 0));
        }
    }
}
