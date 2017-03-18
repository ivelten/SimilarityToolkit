using System;

namespace SimilarityToolkit.Evaluators.UnitTests.Helpers
{
    public static class DistanceEvaluationHelper
    {
        public static decimal EvaluateDistance(PrimitiveEvaluableObject item1, PrimitiveEvaluableObject item2)
        {
            var totalDistance = 0m;

            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<string>().EvaluateDistance(item1.StringProperty, item2.StringProperty);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<byte>().EvaluateDistance(item1.ByteProperty, item2.ByteProperty);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<byte?>().EvaluateDistance(item1.NullableByteProperty, item2.NullableByteProperty);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<short>().EvaluateDistance(item1.Int16Property, item2.Int16Property);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<short?>().EvaluateDistance(item1.NullableInt16Property, item2.NullableInt16Property);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<int>().EvaluateDistance(item1.Int32Property, item2.Int32Property);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<int?>().EvaluateDistance(item1.NullableInt32Property, item2.NullableInt32Property);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<long>().EvaluateDistance(item1.Int64Property, item2.Int64Property);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<long?>().EvaluateDistance(item1.NullableInt64Property, item2.NullableInt64Property);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<float>().EvaluateDistance(item1.SingleProperty, item2.SingleProperty);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<float?>().EvaluateDistance(item1.NullableSingleProperty, item2.NullableSingleProperty);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<double>().EvaluateDistance(item1.DoubleProperty, item2.DoubleProperty);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<double?>().EvaluateDistance(item1.NullableDoubleProperty, item2.NullableDoubleProperty);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<decimal>().EvaluateDistance(item1.DecimalProperty, item2.DecimalProperty);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<decimal?>().EvaluateDistance(item1.NullableDecimalProperty, item2.NullableDecimalProperty);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<DateTime>().EvaluateDistance(item1.DateTimeProperty, item2.DateTimeProperty);
            totalDistance += EvaluatorContainer.GetPrimitiveEvaluator<DateTime?>().EvaluateDistance(item1.NullableDateTimeProperty, item2.NullableDateTimeProperty);

            return totalDistance;
        }
    }
}
