using System;

namespace SimilarityToolkit.Evaluators.Abstractions.Generic
{
    public abstract class SimilarityEvaluatorBase<T> : SimilarityEvaluatorBase
    {
        public abstract decimal EvaluateDistance(T item1, T item2);

        internal override decimal EvaluateDistance(object item1, object item2)
        {
            return EvaluateDistance((T)item1, (T)item2);
        }

        internal override Type EvaluatedType
        {
            get { return typeof(T); }
        }
    }
}
