using SimilarityToolkit.Evaluators.Abstractions;
using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SimilarityToolkit.Evaluators
{
    public static class EvaluatorContainer
    {
        private static readonly ReadOnlyDictionary<Type, SimilarityEvaluator> primitiveEvaluators =
            new ReadOnlyDictionary<Type, SimilarityEvaluator>(
                GetPrimitiveEvaluators()
                    .ToDictionary(k => k.EvaluatedType, v => v));

        public static IEnumerable<SimilarityEvaluator> PrimitiveEvaluators
        {
            get { return primitiveEvaluators.Values; }
        }

        public static SimilarityEvaluator<T> GetPrimitiveEvaluator<T>()
        {
            var evaluatedType = typeof(T);

            if (!primitiveEvaluators.ContainsKey(evaluatedType))
                return null;

            return (SimilarityEvaluator<T>)primitiveEvaluators[evaluatedType];
        }

        private static IEnumerable<SimilarityEvaluator> GetPrimitiveEvaluators()
        {
            yield return new StringSimilarityEvaluator();
            yield return new ByteSimilarityEvaluator();
            yield return new NullableByteSimilarityEvaluator();
            yield return new Int16SimilarityEvaluator();
            yield return new NullableInt16SimilarityEvaluator();
            yield return new Int32SimilarityEvaluator();
            yield return new NullableInt32SimilarityEvaluator();
            yield return new Int64SimilarityEvaluator();
            yield return new NullableInt64SimilarityEvaluator();
            yield return new SingleSimilarityEvaluator();
            yield return new NullableSingleSimilarityEvaluator();
            yield return new DoubleSimilarityEvaluator();
            yield return new NullableDoubleSimilarityEvaluator();
            yield return new DecimalSimilarityEvaluator();
            yield return new NullableDecimalSimilarityEvaluator();
            yield return new DateTimeSimilarityEvaluator();
            yield return new NullableDateTimeSimilarityEvaluator();
        }
    }
}
