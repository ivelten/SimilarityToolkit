using SimilarityToolkit.Evaluators.Abstractions;
using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimilarityToolkit.Evaluators
{
    public class ObjectEvaluator<T> : SimilarityEvaluator<T>
    {
        private readonly Dictionary<Type, SimilarityEvaluator> innerEvaluators;

        public ObjectEvaluator(IEnumerable<SimilarityEvaluator> innerEvaluators = null)
        {
            this.innerEvaluators = new Dictionary<Type, SimilarityEvaluator>();

            AddInnerEvaluator(new StringSimilarityEvaluator());
            AddInnerEvaluator(new Int64SimilarityEvaluator());
            AddInnerEvaluator(new DoubleSimilarityEvaluator());

            if (innerEvaluators != null)
                foreach (var innerEvaluator in innerEvaluators)
                    AddInnerEvaluator(innerEvaluator);
        }

        public override double EvaluateDistance(T item1, T item2)
        {
            // TODO: Here is where the magic should happen:
            // We use all the inner evaluators to evaluate each public property of
            // item1 against the same property on item2.
            throw new NotImplementedException();
        }

        public void AddInnerEvaluator(SimilarityEvaluator evaluator)
        {
            innerEvaluators.Add(evaluator.EvaluatedType, evaluator);
        }

        public IEnumerable<SimilarityEvaluator> InnerEvaluators => innerEvaluators.Values.AsEnumerable();
    }
}
