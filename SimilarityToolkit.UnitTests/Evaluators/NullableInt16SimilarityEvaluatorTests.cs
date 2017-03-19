using FluentAssertions;
using SimilarityToolkit.Evaluators;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using System;
using Xunit;

namespace SimilarityToolkit.UnitTests.Evaluators
{
    public class NullableInt16SimilarityEvaluatorTests
    {
        [Theory]
        [AutoNSubstituteInlineData((short)0, (short)0)]
        [AutoNSubstituteInlineData((short)1, (short)50)]
        [AutoNSubstituteInlineData((short)0, (short)50)]
        [AutoNSubstituteInlineData((short)156, (short)0)]
        [AutoNSubstituteInlineData((short)255, (short)67)]
        [AutoNSubstituteInlineData(null, (short)-67)]
        [AutoNSubstituteInlineData((short)-67, null)]
        [AutoNSubstituteInlineData((short)0, null)]
        [AutoNSubstituteInlineData(null, (short)0)]
        public void Similarity_Test(short? item1, short? item2, NullableInt16SimilarityEvaluator evaluator)
        {
            var expectedDistance = Math.Abs((item1 ?? 0) - (item2 ?? 0));
            var actualDistance = evaluator.EvaluateDistance(item1, item2);

            actualDistance.Should().Be(expectedDistance);
        }
    }
}
