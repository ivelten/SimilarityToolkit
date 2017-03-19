using FluentAssertions;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using System;
using Xunit;

namespace SimilarityToolkit.UnitTests.Evaluators
{
    public class DateTimeSimilarityEvaluatorTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void When_Giving_Date_Only_Should_Calculate_Distance_In_Days(DateTimeSimilarityEvaluator evaluator)
        {
            var item1 = new DateTime(2016, 1, 1);
            var item2 = new DateTime(2016, 12, 31);

            evaluator.EvaluateDistance(item1, item2).Should().Be(365);
        }

        [Theory]
        [AutoNSubstituteData]
        public void When_Giving_Date_And_Time_Should_Calculate_Distance_In_Seconds(DateTimeSimilarityEvaluator evaluator)
        {
            var item1 = new DateTime(2016, 1, 1, 12, 30, 15);
            var item2 = new DateTime(2016, 1, 1, 0, 0, 0);

            evaluator.EvaluateDistance(item1, item2).Should().Be(45015);
        }
    }
}
