using SimilarityToolkit.Evaluators.Abstractions;
using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimilarityToolkit.Evaluators.Generic
{
    public class SimilarityEvaluator<T> : SimilarityEvaluatorBase<T>
    {
        private readonly Dictionary<Type, SimilarityEvaluatorBase> innerEvaluators = new Dictionary<Type, SimilarityEvaluatorBase>();

        public SimilarityEvaluator(IEnumerable<SimilarityEvaluatorBase> innerEvaluators)
        {
            AddInnerEvaluators(innerEvaluators);
        }

        public SimilarityEvaluator()
            : this(SimilarityEvaluatorContainer.PrimitiveEvaluators)
        {
        }

        public IEnumerable<SimilarityEvaluatorBase> InnerEvaluators => innerEvaluators.Values.AsEnumerable();

        protected SimilarityEvaluatorBase GetInnerEvaluatorForType(Type type)
        {
            if (!innerEvaluators.ContainsKey(type))
            {
                if (typeof(IEnumerable).IsAssignableFrom(type))
                    return GetEnumerableEvaluatorForType(type);

                throw new Exception($"No inner evaluator was found for type {type}.");
            }

            return innerEvaluators[type];
        }

        private static SimilarityEvaluatorBase GetEnumerableEvaluatorForType(Type type)
        {
            var genericTypes = type.GenericTypeArguments;

            if (genericTypes.Length != 1)
                throw new Exception($"Type {type} implements {typeof(IEnumerable)}, but it does not implement {typeof(IEnumerable<>)}." +
                    "Evaluation of non-generic enumerable is not possible.");

            var genericType = genericTypes[0];

            var evaluatorType = typeof(EnumerableSimilarityEvaluator<>).MakeGenericType(genericType);

            return (SimilarityEvaluatorBase)Activator.CreateInstance(evaluatorType);
        }

        public override decimal EvaluateDistance(T item1, T item2)
        {
            var distances = new List<decimal>();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var evaluator = GetInnerEvaluatorForType(property.PropertyType);
                var value1 = property.GetValue(item1);
                var value2 = property.GetValue(item2);

                distances.Add(evaluator.EvaluateDistance(value1, value2));
            }

            return distances.Sum();
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
