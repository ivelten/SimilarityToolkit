using SimilarityToolkit.Evaluators.Abstractions;
using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimilarityToolkit.Evaluators
{
    public abstract class CompositeSimilarityEvaluator<T> : SimilarityEvaluator<T>
    {
        private readonly Dictionary<Type, SimilarityEvaluator> innerEvaluators = 
            new Dictionary<Type, SimilarityEvaluator>();

        public CompositeSimilarityEvaluator()
        {
            AddInnerEvaluators(EvaluatorContainer.PrimitiveEvaluators);
        }

        public IEnumerable<SimilarityEvaluator> InnerEvaluators => innerEvaluators.Values.AsEnumerable();

        protected SimilarityEvaluator GetInnerEvaluatorForType(Type type)
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
    }
}
