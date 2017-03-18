using System;
using System.Collections;
using System.Collections.Generic;

namespace SimilarityToolkit.Evaluators
{
    public class EnumerableSimilarityEvaluator : CompositeSimilarityEvaluator<IEnumerable>
    {
        public override decimal EvaluateDistance(IEnumerable item1, IEnumerable item2)
        {
            ValidateTypeRestrictions(item1, item2);

            var totalDistance = 0m;

            var genericType = item1.GetType().GenericTypeArguments[0];
            var genericTypeEvaluator = GetInnerEvaluatorForType(genericType);

            // TODO: Think in a way to compare two random enumerables and get a
            // good assertion of similarity between them

            return totalDistance;
        }

        private static void ValidateTypeRestrictions(IEnumerable item1, IEnumerable item2)
        {
            var item1Type = item1.GetType();
            var item2Type = item2.GetType();

            if (item1Type != typeof(IEnumerable<>))
                throw new ArgumentException($"Parameter {nameof(item1)} does not implement IEnumerable<> generics interface.");

            if (item2Type != typeof(IEnumerable<>))
                throw new ArgumentException($"Parameter {nameof(item2)} does not implement IEnumerable<> generics interface.");

            var genericType1 = item1Type.GenericTypeArguments[0];
            var genericType2 = item2Type.GenericTypeArguments[0];

            if (genericType1 != genericType2)
                throw new ArgumentException($"Enumerator of parameter {nameof(item1)} is of generic type {genericType1} " +
                    $"and emumerator of parameter {nameof(item2)} is of generic type {genericType2}. " +
                    "Generic types of both parameters must be of the same in order to evaluate.");
        }
    }
}
