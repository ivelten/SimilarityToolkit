using SimilarityToolkit.Evaluators.Abstractions;
using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimilarityToolkit.Evaluators
{
    public class ObjectEvaluator<T> : SimilarityEvaluator<T>
    {
        private readonly Dictionary<Type, SimilarityEvaluator> innerEvaluators;

        public ObjectEvaluator()
        {
            innerEvaluators = new Dictionary<Type, SimilarityEvaluator>();
            AddPrimitivetInnerEvaluators();
        }

        private void AddPrimitivetInnerEvaluators()
        {
            AddInnerEvaluator(new StringSimilarityEvaluator());
            AddInnerEvaluator(new ByteSimilarityEvaluator());
            AddInnerEvaluator(new NullableByteSimilarityEvaluator());
            AddInnerEvaluator(new Int16SimilarityEvaluator());
            AddInnerEvaluator(new NullableInt16SimilarityEvaluator());
            AddInnerEvaluator(new Int32SimilarityEvaluator());
            AddInnerEvaluator(new NullableInt32SimilarityEvaluator());
            AddInnerEvaluator(new Int64SimilarityEvaluator());
            AddInnerEvaluator(new NullableInt64SimilarityEvaluator());
            AddInnerEvaluator(new SingleSimilarityEvaluator());
            AddInnerEvaluator(new NullableSingleSimilarityEvaluator());
            AddInnerEvaluator(new DoubleSimilarityEvaluator());
            AddInnerEvaluator(new NullableDoubleSimilarityEvaluator());
            AddInnerEvaluator(new DecimalSimilarityEvaluator());
            AddInnerEvaluator(new NullableDecimalSimilarityEvaluator());
        }

        public override decimal EvaluateDistance(T item1, T item2)
        {
            var totalDistance = 0M;
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var evaluator = innerEvaluators[property.PropertyType];

                if (evaluator == null)
                    throw new Exception($"No inner evaluator was found for type {property.PropertyType}.");

                var value1 = item1 != null ? property.GetValue(item1) : null;
                var value2 = item2 != null ? property.GetValue(item2) : null;

                totalDistance += evaluator.EvaluateDistance(value1, value2);
            }

            return totalDistance;
        }

        private SimilarityEvaluator GetEvaluator(Type type)
        {
            if (!innerEvaluators.ContainsKey(type))
                return null;

            return innerEvaluators[type];
        }

        public void AddInnerEvaluator(SimilarityEvaluator evaluator)
        {
            innerEvaluators.Add(evaluator.EvaluatedType, evaluator);
        }

        public IEnumerable<SimilarityEvaluator> InnerEvaluators => innerEvaluators.Values.AsEnumerable();
    }
}
