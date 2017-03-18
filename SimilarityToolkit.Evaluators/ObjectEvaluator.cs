﻿using SimilarityToolkit.Evaluators.Abstractions;
using SimilarityToolkit.Evaluators.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SimilarityToolkit.Evaluators
{
    public class ObjectEvaluator<T> : SimilarityEvaluator<T>
    {
        private readonly Dictionary<Type, SimilarityEvaluator> innerEvaluators;

        public ObjectEvaluator(IEnumerable<SimilarityEvaluator> innerEvaluators = null)
        {
            this.innerEvaluators = new Dictionary<Type, SimilarityEvaluator>();

            AddDefaultInnerEvaluators();

            if (innerEvaluators != null)
                foreach (var innerEvaluator in innerEvaluators)
                    AddInnerEvaluator(innerEvaluator);
        }

        private void AddDefaultInnerEvaluators()
        {
            AddInnerEvaluator(new StringSimilarityEvaluator());
            AddInnerEvaluator(new Int64SimilarityEvaluator());
            AddInnerEvaluator(new DoubleSimilarityEvaluator());
        }

        public override double EvaluateDistance(T item1, T item2)
        {
            var totalDistance = 0.0;
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var evaluator = innerEvaluators[property.PropertyType];

                if (evaluator == null)
                    throw new Exception($"No inner evaluator was found for type {property.PropertyType}.");

                var value1 = item1 != null ? property.GetValue(item1) : null;
                var value2 = item2 != null ? property.GetValue(item2) : null;

                totalDistance += evaluator.EvaluateDistance(value1, value2);
            }

            return totalDistance;
        }

        private SimilarityEvaluator GetEvaluator(Type type)
        {
            if (!innerEvaluators.ContainsKey(type))
                return null;

            return innerEvaluators[type];
        }

        public void AddInnerEvaluator(SimilarityEvaluator evaluator)
        {
            innerEvaluators.Add(evaluator.EvaluatedType, evaluator);
        }

        public IEnumerable<SimilarityEvaluator> InnerEvaluators => innerEvaluators.Values.AsEnumerable();
    }
}
