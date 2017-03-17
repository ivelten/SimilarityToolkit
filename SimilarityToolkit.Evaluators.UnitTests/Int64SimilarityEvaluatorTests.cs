using FluentAssertions;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using System;
using Xunit;

namespace SimilarityToolkit.Evaluators.UnitTests
{
    public class Int64SimilarityEvaluatorTests
    {
        [Theory]
        [AutoNSubstituteInlineData(0, 0)]
        [AutoNSubstituteInlineData(-1, 50)]
        [AutoNSubstituteInlineData(0, 50)]
        [AutoNSubstituteInlineData(1567, 0)]
        [AutoNSubstituteInlineData(987, -67)]
        public void Similarity_Test_01(long item1, long item2, Int64SimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(item1, item2).Should().Be(Math.Abs(item1 - item2));
        }

        [Theory]
        [AutoNSubstituteInlineData(0, 0)]
        [AutoNSubstituteInlineData(-1, 50)]
        [AutoNSubstituteInlineData(0, 50)]
        [AutoNSubstituteInlineData(1567, 0)]
        [AutoNSubstituteInlineData(987, -67)]
        [AutoNSubstituteInlineData(null, -67)]
        [AutoNSubstituteInlineData(-67, null)]
        [AutoNSubstituteInlineData(0, null)]
        [AutoNSubstituteInlineData(null, 0)]
        public void Similarity_Test_01(long? item1, long? item2, Int64SimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(item1, item2).Should().Be(Math.Abs(item1 ?? 0 - item2 ?? 0));
        }
    }
}
