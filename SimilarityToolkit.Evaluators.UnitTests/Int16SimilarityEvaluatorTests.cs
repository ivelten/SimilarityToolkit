using FluentAssertions;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using System;
using Xunit;

namespace SimilarityToolkit.Evaluators.UnitTests
{
    public class Int16SimilarityEvaluatorTests
    {
        [Theory]
        [AutoNSubstituteInlineData(0, 0)]
        [AutoNSubstituteInlineData(1, 50)]
        [AutoNSubstituteInlineData(0, 50)]
        [AutoNSubstituteInlineData(156, 0)]
        [AutoNSubstituteInlineData(255, 67)]
        public void Similarity_Test(short item1, short item2, Int16SimilarityEvaluator evaluator)
        {
            var expectedDistance = Math.Abs(item1 - item2);
            var actualDistance = evaluator.EvaluateDistance(item1, item2);

            actualDistance.Should().Be(expectedDistance);
        }
    }
}
