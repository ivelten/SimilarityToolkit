using SimilarityToolkit.Evaluators.UnitTests.Helpers.Evaluables;
using System;
using System.Collections.Generic;
using System.Linq;
using Container = SimilarityToolkit.SimilarityEvaluatorContainer;

namespace SimilarityToolkit.Evaluators.UnitTests.Helpers
{
    public static class DistanceEvaluationHelper
    {
        public static decimal EvaluateDistance(PrimitiveEvaluable item1, PrimitiveEvaluable item2)
        {
            var distances = new List<decimal>();

            distances.Add(Container.GetPrimitiveEvaluator<string>().EvaluateDistance(item1.StringProperty, item2.StringProperty));
            distances.Add(Container.GetPrimitiveEvaluator<byte>().EvaluateDistance(item1.ByteProperty, item2.ByteProperty));
            distances.Add(Container.GetPrimitiveEvaluator<byte?>().EvaluateDistance(item1.NullableByteProperty, item2.NullableByteProperty));
            distances.Add(Container.GetPrimitiveEvaluator<short>().EvaluateDistance(item1.Int16Property, item2.Int16Property));
            distances.Add(Container.GetPrimitiveEvaluator<short?>().EvaluateDistance(item1.NullableInt16Property, item2.NullableInt16Property));
            distances.Add(Container.GetPrimitiveEvaluator<int>().EvaluateDistance(item1.Int32Property, item2.Int32Property));
            distances.Add(Container.GetPrimitiveEvaluator<int?>().EvaluateDistance(item1.NullableInt32Property, item2.NullableInt32Property));
            distances.Add(Container.GetPrimitiveEvaluator<long>().EvaluateDistance(item1.Int64Property, item2.Int64Property));
            distances.Add(Container.GetPrimitiveEvaluator<long?>().EvaluateDistance(item1.NullableInt64Property, item2.NullableInt64Property));
            distances.Add(Container.GetPrimitiveEvaluator<float>().EvaluateDistance(item1.SingleProperty, item2.SingleProperty));
            distances.Add(Container.GetPrimitiveEvaluator<float?>().EvaluateDistance(item1.NullableSingleProperty, item2.NullableSingleProperty));
            distances.Add(Container.GetPrimitiveEvaluator<double>().EvaluateDistance(item1.DoubleProperty, item2.DoubleProperty));
            distances.Add(Container.GetPrimitiveEvaluator<double?>().EvaluateDistance(item1.NullableDoubleProperty, item2.NullableDoubleProperty));
            distances.Add(Container.GetPrimitiveEvaluator<decimal>().EvaluateDistance(item1.DecimalProperty, item2.DecimalProperty));
            distances.Add(Container.GetPrimitiveEvaluator<decimal?>().EvaluateDistance(item1.NullableDecimalProperty, item2.NullableDecimalProperty));
            distances.Add(Container.GetPrimitiveEvaluator<DateTime>().EvaluateDistance(item1.DateTimeProperty, item2.DateTimeProperty));
            distances.Add(Container.GetPrimitiveEvaluator<DateTime?>().EvaluateDistance(item1.NullableDateTimeProperty, item2.NullableDateTimeProperty));

            return distances.Sum();
        }
    }
}
