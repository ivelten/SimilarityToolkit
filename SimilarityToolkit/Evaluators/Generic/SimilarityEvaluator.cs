using SimilarityToolkit.Evaluators.Abstractions;
using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimilarityToolkit.Evaluators.Generic
{
    public class SimilarityEvaluator<T> : SimilarityEvaluatorBase<T>
    {
        private readonly Dictionary<Type, SimilarityEvaluatorBase> innerEvaluators = new Dictionary<Type, SimilarityEvaluatorBase>();

        public SimilarityEvaluator()
        {
            AddInnerEvaluators(SimilarityEvaluatorContainer.PrimitiveEvaluators);
        }

        public IEnumerable<SimilarityEvaluatorBase> InnerEvaluators => innerEvaluators.Values.AsEnumerable();

        protected SimilarityEvaluatorBase GetInnerEvaluatorForType(Type type)
        {
            if (!innerEvaluators.ContainsKey(type))
                throw new Exception($"No inner evaluator was found for type {type}.");

            return innerEvaluators[type];
        }

        public override decimal EvaluateDistance(T item1, T item2)
        {
            var totalDistance = 0m;
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var evaluator = GetInnerEvaluatorForType(property.PropertyType);
                totalDistance += evaluator.EvaluateDistance(property.GetValue(item1), property.GetValue(item2));
            }

            return totalDistance;
        }

        public void AddInnerEvaluator(SimilarityEvaluatorBase evaluator)
        {
            if (innerEvaluators.ContainsKey(evaluator.EvaluatedType))
                innerEvaluators.Remove(evaluator.EvaluatedType);

            innerEvaluators.Add(evaluator.EvaluatedType, evaluator);
        }

        public void AddInnerEvaluators(IEnumerable<SimilarityEvaluatorBase> evaluators)
        {
            foreach (var evaluator in evaluators)
                AddInnerEvaluator(evaluator);
        }
    }
}
