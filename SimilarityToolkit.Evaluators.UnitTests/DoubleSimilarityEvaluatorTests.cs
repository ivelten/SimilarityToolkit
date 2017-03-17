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
        public void Similarity_Test_01(double item1, double item2, DoubleSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(item1, item2).Should().Be(Math.Abs(item1 - item2));
        }

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
        public void Similarity_Test_02(double? item1, double? item2, DoubleSimilarityEvaluator evaluator)
        {
            var expected = Math.Abs((item1 ?? 0) - (item2 ?? 0));
            evaluator.EvaluateDistance(item1, item2).Should().Be(expected);
        }
    }
}
