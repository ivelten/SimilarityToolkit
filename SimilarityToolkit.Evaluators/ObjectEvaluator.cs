using System.Reflection;

namespace SimilarityToolkit.Evaluators
{
    public class ObjectEvaluator<T> : CompositeSimilarityEvaluator<T>
    {
        public override decimal EvaluateDistance(T item1, T item2)
        {
            var totalDistance = 0m;
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var evaluator = GetInnerEvaluatorForType(property.PropertyType);
                totalDistance += evaluator.EvaluateDistance(property.GetValue(item1), property.GetValue(item2));
            }

            return totalDistance;
        }
    }
}
