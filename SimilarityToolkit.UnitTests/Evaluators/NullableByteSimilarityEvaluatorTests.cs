using FluentAssertions;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using System;
using Xunit;

namespace SimilarityToolkit.UnitTests.Evaluators
{
    public class NullableByteSimilarityEvaluatorTests
    {
        [Theory]
        [AutoNSubstituteInlineData((byte)0, (byte)0)]
        [AutoNSubstituteInlineData((byte)1, (byte)50)]
        [AutoNSubstituteInlineData((byte)0, (byte)50)]
        [AutoNSubstituteInlineData((byte)156, (byte)0)]
        [AutoNSubstituteInlineData((byte)255, (byte)67)]
        [AutoNSubstituteInlineData(null, (byte)67)]
        [AutoNSubstituteInlineData((byte)67, null)]
        [AutoNSubstituteInlineData((byte)0, null)]
        [AutoNSubstituteInlineData(null, (byte)0)]
        public void Similarity_Test(byte? item1, byte? item2, NullableByteSimilarityEvaluator evaluator)
        {
            var expectedDistance = Math.Abs((item1 ?? 0) - (item2 ?? 0));
            var actualDistance = evaluator.EvaluateDistance(item1, item2);

            actualDistance.Should().Be(expectedDistance);
        }
    }
}
