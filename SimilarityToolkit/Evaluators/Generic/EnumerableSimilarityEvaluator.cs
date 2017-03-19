using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;
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
            var distances = new List<decimal>();

            foreach (var item1 in bigger)
            {
                var results = new List<Tuple<T, decimal>>();

                for (var index = 0; index < bigger.Count; index++)
                {
                    var item2 = smaller.ElementAtOrDefault(index);

                    var distance = innerEvaluator.EvaluateDistance(item1, item2);
                    var result = new Tuple<T, decimal>(item2, distance);

                    results.Add(result);
                }

                var bestResult = results.OrderBy(r => r.Item2).First();

                distances.Add(bestResult.Item2);
                smaller.Remove(bestResult.Item1);
            }

            return distances.Sum();
        }
    }
}
