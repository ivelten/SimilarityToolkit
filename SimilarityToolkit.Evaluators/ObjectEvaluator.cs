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
            AddInnerEvaluators(EvaluatorContainer.PrimitiveEvaluators);
        }

        public override decimal EvaluateDistance(T item1, T item2)
        {
            var totalDistance = 0m;
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var evaluator = GetEvaluator(property.PropertyType);
                totalDistance += evaluator.EvaluateDistance(property.GetValue(item1), property.GetValue(item2));
            }

            return totalDistance;
        }

        private SimilarityEvaluator GetEvaluator(Type type)
        {
            if (!innerEvaluators.ContainsKey(type))
                throw new Exception($"No inner evaluator was found for type {type}.");

            return innerEvaluators[type];
        }

        public void AddInnerEvaluator(SimilarityEvaluator evaluator)
        {
            if (innerEvaluators.ContainsKey(evaluator.EvaluatedType))
                innerEvaluators.Remove(evaluator.EvaluatedType);

            innerEvaluators.Add(evaluator.EvaluatedType, evaluator);
        }

        public void AddInnerEvaluators(IEnumerable<SimilarityEvaluator> evaluators)
        {
            foreach (var evaluator in evaluators)
                AddInnerEvaluator(evaluator);
        }

        public IEnumerable<SimilarityEvaluator> InnerEvaluators => innerEvaluators.Values.AsEnumerable();
    }
}
