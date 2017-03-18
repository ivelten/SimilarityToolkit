using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class Int16SimilarityEvaluatr : SimilarityEvaluator<short>
    {
        public override decimal EvaluateDistance(short item1, short item2)
        {
            return Math.Abs(item1 - item2);
        }
    }
}
