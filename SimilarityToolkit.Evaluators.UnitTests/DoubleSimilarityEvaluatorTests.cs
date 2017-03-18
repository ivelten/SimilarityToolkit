using FluentAssertions;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using System;
using Xunit;

namespace SimilarityToolkit.Evaluators.UnitTests
{
    public class DoubleSimilarityEvaluatorTests
    {
        [Theory]
        [AutoNSubstituteInlineData(0.0, 0.0)]
        [AutoNSubstituteInlineData(-1.7, 50.8)]
        [AutoNSubstituteInlineData(0.0, 50.8843)]
        [AutoNSubstituteInlineData(1567.12, 0.0)]
        [AutoNSubstituteInlineData(987.0, -67.2312)]
        public void Similarity_Test(double item1, double item2, DoubleSimilarityEvaluator evaluator)
        {
            var expectedDistance = Math.Abs((decimal)item1 - (decimal)item2);
            var actualDistance = evaluator.EvaluateDistance(item1, item2);

            actualDistance.Should().Be(expectedDistance);
        }
    }
}
