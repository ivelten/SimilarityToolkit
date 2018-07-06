using SimilarityToolkit.Evaluators.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimilarityToolkit.Evaluators.UnitTests.Helpers
{
    public static class EvaluationHelper
    {
        public static SimilarityEvaluationResult<PrimitiveEvaluableObject> Evaluate(PrimitiveEvaluableObject item1, PrimitiveEvaluableObject item2)
        {
            var results = new List<SimilarityEvaluationResult>();

            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<string>().Evaluate(item1.StringProperty, item2.StringProperty));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<byte>().Evaluate(item1.ByteProperty, item2.ByteProperty));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<byte?>().Evaluate(item1.NullableByteProperty, item2.NullableByteProperty));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<short>().Evaluate(item1.Int16Property, item2.Int16Property));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<short?>().Evaluate(item1.NullableInt16Property, item2.NullableInt16Property));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<int>().Evaluate(item1.Int32Property, item2.Int32Property));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<int?>().Evaluate(item1.NullableInt32Property, item2.NullableInt32Property));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<long>().Evaluate(item1.Int64Property, item2.Int64Property));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<long?>().Evaluate(item1.NullableInt64Property, item2.NullableInt64Property));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<float>().Evaluate(item1.SingleProperty, item2.SingleProperty));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<float?>().Evaluate(item1.NullableSingleProperty, item2.NullableSingleProperty));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<double>().Evaluate(item1.DoubleProperty, item2.DoubleProperty));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<double?>().Evaluate(item1.NullableDoubleProperty, item2.NullableDoubleProperty));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<decimal>().Evaluate(item1.DecimalProperty, item2.DecimalProperty));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<decimal?>().Evaluate(item1.NullableDecimalProperty, item2.NullableDecimalProperty));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<DateTime>().Evaluate(item1.DateTimeProperty, item2.DateTimeProperty));
            results.Add(SimilarityEvaluatorRoot.GetPrimitiveEvaluator<DateTime?>().Evaluate(item1.NullableDateTimeProperty, item2.NullableDateTimeProperty));

            return new SimilarityEvaluationResult<PrimitiveEvaluableObject>(item1, item2, results.Sum(r => r.Distance), results.Average(r => r.Rate));
        }

        internal static decimal EvaluateDistance(PrimitiveEnumerableEvaluableObject item1, PrimitiveEnumerableEvaluableObject item2)
        {
            var distance = 0m;

            // TODO: calculate distance

            return distance;
        }
    }
}
