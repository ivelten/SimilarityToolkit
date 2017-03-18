using FluentAssertions;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using System;
using Xunit;

namespace SimilarityToolkit.Evaluators.UnitTests
{
    public class NullableSingleSimilarityEvaluatorTests
    {
        [Theory]
        [AutoNSubstituteInlineData(0.0f, 0.0f)]
        [AutoNSubstituteInlineData(-1.7f, 50.8f)]
        [AutoNSubstituteInlineData(0.0f, 50.8843f)]
        [AutoNSubstituteInlineData(1567.12f, 0.0f)]
        [AutoNSubstituteInlineData(987.0f, -67.2312f)]
        [AutoNSubstituteInlineData(null, -67.768f)]
        [AutoNSubstituteInlineData(-67.98798f, null)]
        [AutoNSubstituteInlineData(0.0f, null)]
        [AutoNSubstituteInlineData(null, 0.0f)]
        public void Similarity_Test(float? item1, float? item2, NullableSingleSimilarityEvaluator evaluator)
        {
            var expectedDistance = Math.Abs((decimal)(item1 ?? 0) - (decimal)(item2 ?? 0));
            var actualDistance = evaluator.EvaluateDistance(item1, item2);

            actualDistance.Should().Be(expectedDistance);
        }
    }
}
