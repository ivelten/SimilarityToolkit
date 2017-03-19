using FluentAssertions;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using System;
using Xunit;

namespace SimilarityToolkit.UnitTests.Evaluators
{
    public class NullableDateTimeSimilarityEvaluatorTests
    {
        [Theory]
        [AutoNSubstituteData]
        public void When_Giving_Date_Only_Should_Calculate_Distance_In_Days(NullableDateTimeSimilarityEvaluator evaluator)
        {
            var item1 = new DateTime?(new DateTime(2016, 1, 1));
            var item2 = new DateTime?(new DateTime(2016, 12, 31));

            evaluator.EvaluateDistance(item1, item2).Should().Be(365);
        }

        [Theory]
        [AutoNSubstituteData]
        public void When_Giving_First_And_Time_Should_Calculate_Distance_In_Seconds(NullableDateTimeSimilarityEvaluator evaluator)
        {
            var item1 = new DateTime?(new DateTime(2016, 1, 1, 0, 0, 0));
            var item2 = new DateTime?(new DateTime(2016, 1, 1, 12, 30, 15));

            evaluator.EvaluateDistance(item1, item2).Should().Be(45015);
        }

        [Theory]
        [AutoNSubstituteData]
        public void When_Giving_Second_Date_And_Time_Should_Calculate_Distance_In_Seconds(NullableDateTimeSimilarityEvaluator evaluator)
        {
            var item1 = new DateTime?(new DateTime(2016, 1, 1, 12, 30, 15));
            var item2 = new DateTime?(new DateTime(2016, 1, 1, 0, 0, 0));

            evaluator.EvaluateDistance(item1, item2).Should().Be(45015);
        }

        [Theory]
        [AutoNSubstituteData]
        public void When_First_Date_Is_Null_Should_Give_Distance_From_Min_Date_In_Days(NullableDateTimeSimilarityEvaluator evaluator)
        {
            var item1 = new DateTime?();
            var item2 = new DateTime?(new DateTime(2016, 12, 31));

            evaluator.EvaluateDistance(item1, item2).Should().Be(736328);
        }

        [Theory]
        [AutoNSubstituteData]
        public void When_Second_Date_Is_Null_Should_Give_Distance_From_Min_Date_In_Days(NullableDateTimeSimilarityEvaluator evaluator)
        {
            var item1 = new DateTime?(new DateTime(2016, 12, 31));
            var item2 = new DateTime?();

            evaluator.EvaluateDistance(item1, item2).Should().Be(736328);
        }

        [Theory]
        [AutoNSubstituteData]
        public void When_Two_Dates_Are_Null_Should_Give_Zero_Distance(NullableDateTimeSimilarityEvaluator evaluator)
        {
            var item1 = new DateTime?();
            var item2 = new DateTime?();

            evaluator.EvaluateDistance(item1, item2).Should().Be(0);
        }
    }
}
