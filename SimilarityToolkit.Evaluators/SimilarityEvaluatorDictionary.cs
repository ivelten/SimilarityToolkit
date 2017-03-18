using SimilarityToolkit.Evaluators.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SimilarityToolkit.Evaluators
{
    public class SimilarityEvaluatorDictionary : ReadOnlyDictionary<Type, SimilarityEvaluatorBase>
    {
        private SimilarityEvaluatorDictionary(IDictionary<Type, SimilarityEvaluatorBase> dictionary) 
            : base(dictionary)
        {
        }

        public static SimilarityEvaluatorDictionary From(IEnumerable<SimilarityEvaluatorBase> evaluators)
        {
            var dictionary = evaluators.ToDictionary(k => k.EvaluatedType, v => v);
            return new SimilarityEvaluatorDictionary(dictionary);
        }
    }
}
