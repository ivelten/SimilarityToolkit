using SimilarityToolkit.Evaluators.Abstractions;
using System;

namespace SimilarityToolkit.Evaluators
{
    public class StringSimilarityEvaluator : ISimilarityEvaluator<string, string>
    {
        public double EvaluateDistance(string item1, string item2)
        {
            if (string.IsNullOrEmpty(item1) && string.IsNullOrEmpty(item2))
            {
                return 0;
            }

            var length1 = item1?.Length ?? 0;
            var length2 = item2?.Length ?? 0;

            var distances = new int[length1 + 1, length2 + 1];

            for (var i = 0; i <= length1; distances[i, 0] = i++) { }
            for (var j = 0; j <= length2; distances[0, j] = j++) { }

            for (var i = 1; i <= length1; i++)
            {
                for (int j = 1; j <= length2; j++)
                {
                    int cost = item2[j - 1] == item1[i - 1] ? 0 : 1;

                    distances[i, j] = Math.Min(
                        Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                        distances[i - 1, j - 1] + cost);
                }
            }

            return distances[length1, length2];
        }
    }
}
