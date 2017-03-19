using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimilarityToolkit.Evaluators.Generic
{
    public class EnumerableSimilarityEvaluator<T> : SimilarityEvaluatorBase<IEnumerable<T>>
    {
        private readonly SimilarityEvaluatorBase<T> innerEvaluator;

        public EnumerableSimilarityEvaluator(SimilarityEvaluatorBase<T> innerEvaluator)
        {
            if (innerEvaluator == null)
                throw new ArgumentNullException(nameof(innerEvaluator));

            this.innerEvaluator = innerEvaluator;
        }

        public EnumerableSimilarityEvaluator()
        {
            var innerEvaluator = SimilarityEvaluatorContainer.GetPrimitiveEvaluator<T>();

            if (innerEvaluator == null)
                innerEvaluator = new SimilarityEvaluator<T>();

            this.innerEvaluator = innerEvaluator;
        }

        public SimilarityEvaluatorBase<T> InnerEvaluator => innerEvaluator;

        public override decimal EvaluateDistance(IEnumerable<T> item1, IEnumerable<T> item2)
        {
            var item1List = item1 != null
                ? item1.Select(i => new ReferenceWrapper<T>(i)).ToList()
                : new List<ReferenceWrapper<T>>();

            var item2List = item2 != null
                ? item2.Select(i => new ReferenceWrapper<T>(i)).ToList()
                : new List<ReferenceWrapper<T>>();

            if (item1List.Count >= item2List.Count)
                return GetDistanceFromBiggerToSmaller(item1List, item2List);

            return GetDistanceFromBiggerToSmaller(item2List, item1List);
        }

        private decimal GetDistanceFromBiggerToSmaller(List<ReferenceWrapper<T>> bigger, List<ReferenceWrapper<T>> smaller)
        {
            var allEvaluationSets = BuildEvaluationSets(bigger, smaller);
            var chosenEvaluationSets = ChooseBestEvaluationSets(allEvaluationSets);

            return chosenEvaluationSets.Sum(s => s.Distance);
        }

        private static List<EvaluationSet<T>> ChooseBestEvaluationSets(List<EvaluationSet<T>> evaluationSets)
        {
            evaluationSets = evaluationSets.OrderBy(s => s.Distance).ToList();

            var chosenEvaluationSets = new List<EvaluationSet<T>>();

            while (evaluationSets.Count > 0)
            {
                var set = evaluationSets.First();

                chosenEvaluationSets.Add(set);

                evaluationSets.RemoveAll(s =>
                       s.Item1 == set.Item1
                    || s.Item1 == set.Item2
                    || s.Item2 == set.Item1
                    || s.Item2 == set.Item2);
            }

            return chosenEvaluationSets;
        }

        private List<EvaluationSet<T>> BuildEvaluationSets(List<ReferenceWrapper<T>> bigger, List<ReferenceWrapper<T>> smaller)
        {
            var allEvaluationSets = new List<EvaluationSet<T>>();

            while (smaller.Count < bigger.Count)
                smaller.Add(new ReferenceWrapper<T>());

            foreach (var left in bigger)
                foreach (var right in smaller)
                    allEvaluationSets.Add(BuildEvaluationSet(left, right));

            return allEvaluationSets;
        }

        private EvaluationSet<T> BuildEvaluationSet(ReferenceWrapper<T> left, ReferenceWrapper<T> right)
        {
            var distance = innerEvaluator.EvaluateDistance(left.Item, right.Item);
            return new EvaluationSet<T>(left, right, distance);
        }
    }
}
