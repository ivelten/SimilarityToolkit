using FluentAssertions;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using System;
using Xunit;

namespace SimilarityToolkit.Evaluators.UnitTests
{
    public class NullableInt64SimilarityEvaluatorTests
    {
        [Theory]
        [AutoNSubstituteInlineData(0, 0)]
        [AutoNSubstituteInlineData(1, 50)]
        [AutoNSubstituteInlineData(0, 50)]
        [AutoNSubstituteInlineData(156, 0)]
        [AutoNSubstituteInlineData(255, 67)]
        [AutoNSubstituteInlineData(null, -67)]
        [AutoNSubstituteInlineData(-67, null)]
        [AutoNSubstituteInlineData(0, null)]
        [AutoNSubstituteInlineData(null, 0)]
        public void Similarity_Test(long? item1, long? item2, NullableInt64SimilarityEvaluator evaluator)
        {
            var expectedDistance = Math.Abs((item1 ?? 0) - (item2 ?? 0));
            var actualDistance = evaluator.EvaluateDistance(item1, item2);

            actualDistance.Should().Be(expectedDistance);
        }
    }
}
