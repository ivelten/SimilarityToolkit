﻿using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class NullableByteSimilarityEvaluator : SimilarityEvaluator<byte?>
    {
        public override decimal EvaluateDistance(byte? item1, byte? item2)
        {
            return Math.Abs((item1 ?? 0) - (item2 ?? 0));
        }
    }
}