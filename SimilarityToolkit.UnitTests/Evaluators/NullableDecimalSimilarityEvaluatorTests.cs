using FluentAssertions;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using System;
using Xunit;

namespace SimilarityToolkit.UnitTests.Evaluators
{
    public class NullableDecimalSimilarityEvaluatorTests
    {
        [Theory]
        [AutoNSubstituteInlineData(0.0, 0.0)]
        [AutoNSubstituteInlineData(-1.7, 50.8)]
        [AutoNSubstituteInlineData(0.0, 50.8843)]
        [AutoNSubstituteInlineData(1567.12, 0.0)]
        [AutoNSubstituteInlineData(987.0, -67.2312)]
        [AutoNSubstituteInlineData(null, -67.768)]
        [AutoNSubstituteInlineData(-67.98798, null)]
        [AutoNSubstituteInlineData(0.0, null)]
        [AutoNSubstituteInlineData(null, 0.0)]
        public void Similarity_Test(double? item1, double? item2, NullableDecimalSimilarityEvaluator evaluator)
        {
            var castedItem1 = (decimal?)item1;
            var castedItem2 = (decimal?)item2;

            var expectedDistance = Math.Abs((castedItem1 ?? 0) - (castedItem2 ?? 0));
            var actualDistance = evaluator.EvaluateDistance(castedItem1, castedItem2);

            actualDistance.Should().Be(expectedDistance);
        }
    }
}
