using System;

namespace SimilarityToolkit.Evaluators.UnitTests.Helpers
{
    public static class DistanceEvaluationHelper
    {
        public static decimal EvaluateDistance(PrimitiveEvaluableObject item1, PrimitiveEvaluableObject item2)
        {
            var distance = 0m;

            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<string>().EvaluateDistance(item1.StringProperty, item2.StringProperty);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<byte>().EvaluateDistance(item1.ByteProperty, item2.ByteProperty);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<byte?>().EvaluateDistance(item1.NullableByteProperty, item2.NullableByteProperty);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<short>().EvaluateDistance(item1.Int16Property, item2.Int16Property);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<short?>().EvaluateDistance(item1.NullableInt16Property, item2.NullableInt16Property);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<int>().EvaluateDistance(item1.Int32Property, item2.Int32Property);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<int?>().EvaluateDistance(item1.NullableInt32Property, item2.NullableInt32Property);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<long>().EvaluateDistance(item1.Int64Property, item2.Int64Property);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<long?>().EvaluateDistance(item1.NullableInt64Property, item2.NullableInt64Property);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<float>().EvaluateDistance(item1.SingleProperty, item2.SingleProperty);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<float?>().EvaluateDistance(item1.NullableSingleProperty, item2.NullableSingleProperty);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<double>().EvaluateDistance(item1.DoubleProperty, item2.DoubleProperty);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<double?>().EvaluateDistance(item1.NullableDoubleProperty, item2.NullableDoubleProperty);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<decimal>().EvaluateDistance(item1.DecimalProperty, item2.DecimalProperty);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<decimal?>().EvaluateDistance(item1.NullableDecimalProperty, item2.NullableDecimalProperty);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<DateTime>().EvaluateDistance(item1.DateTimeProperty, item2.DateTimeProperty);
            distance += SimilarityEvaluatorContainer.GetPrimitiveEvaluator<DateTime?>().EvaluateDistance(item1.NullableDateTimeProperty, item2.NullableDateTimeProperty);

            return distance;
        }

        internal static decimal EvaluateDistance(PrimitiveEnumerableEvaluableObject item1, PrimitiveEnumerableEvaluableObject item2)
        {
            var distance = 0m;

            // TODO: calculate distance

            return distance;
        }
    }
}
