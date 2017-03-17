using System;

namespace SimilarityToolkit.Evaluators.Abstractions.Generic
{
    public abstract class SimilarityEvaluator<T> : SimilarityEvaluator
    {
        public abstract double EvaluateDistance(T item1, T item2);

        public override double EvaluateDistance(object item1, object item2)
        {
            if (!(item1 is T))
                throw new InvalidCastException($"{nameof(item1)} must be of type {typeof(T)}.");

            if (!(item2 is T))
                throw new InvalidCastException($"{nameof(item2)} must be of type {typeof(T)}.");

            return EvaluateDistance((T)item1, (T)item2);
        }

        public override Type EvaluatedType
        {
            get { return typeof(T); }
        }
    }
}
