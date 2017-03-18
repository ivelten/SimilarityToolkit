using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimilarityToolkit.Evaluators.Generic
{
    public class EnumerableSimilarityEvaluator<T> : SimilarityEvaluatorBase<IEnumerable<T>>
    {
        private readonly SimilarityEvaluatorBase<T> innerEvaluator = SimilarityEvaluatorContainer.GetPrimitiveEvaluator<T>();

        public override decimal EvaluateDistance(IEnumerable<T> item1, IEnumerable<T> item2)
        {
            var item1List = item1.ToList();
            var item2List = item2.ToList();

            if (item1List.Count > item2List.Count)
                return DistanceFromBiggerToSmaller(item1List, item2List);

            return DistanceFromBiggerToSmaller(item2List, item1List);
        }

        private decimal DistanceFromBiggerToSmaller(List<T> bigger, List<T> smaller)
        {
            var totalDistance = 0m;

            foreach (var item1 in bigger)
            {
                var results = new List<SimilarityEvaluationResult<T>>();

                for (var index = 0; index < bigger.Count; index++)
                {
                    var item2 = smaller.ElementAtOrDefault(index);

                    var distance = innerEvaluator.EvaluateDistance(item1, item2);
                    var result = new SimilarityEvaluationResult<T>(item1, item2, distance);

                    results.Add(result);
                }

                var bestResult = results.OrderBy(r => r.Distance).First();

                totalDistance += bestResult.Distance;
                smaller.Remove(bestResult.Item2);
            }

            return totalDistance;
        }

        private static void ValidateTypeRestrictions(IEnumerable item1, IEnumerable item2)
        {
            var item1Type = item1.GetType();
            var item2Type = item2.GetType();

            if (item1Type != typeof(IEnumerable<>))
                throw new ArgumentException($"Parameter {nameof(item1)} does not implement generic IEnumerable<> interface.");

            if (item2Type != typeof(IEnumerable<>))
                throw new ArgumentException($"Parameter {nameof(item2)} does not implement generic IEnumerable<> interface.");

            var genericType1 = item1Type.GenericTypeArguments[0];
            var genericType2 = item2Type.GenericTypeArguments[0];

            if (genericType1 != genericType2)
                throw new ArgumentException($"Enumerator of parameter {nameof(item1)} is of generic type {genericType1} " +
                    $"and emumerator of parameter {nameof(item2)} is of generic type {genericType2}. " +
                    "Generic types of both parameters must be of the same in order to evaluate.");
        }
    }
}
