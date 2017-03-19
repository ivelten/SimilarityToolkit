using FluentAssertions;
using SimilarityToolkit.Evaluators.Abstractions;
using SimilarityToolkit.Evaluators.Generic;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using SimilarityToolkit.Evaluators.UnitTests.Helpers;
using SimilarityToolkit.Evaluators.UnitTests.Helpers.Evaluables;
using System;
using Xunit;

namespace SimilarityToolkit.UnitTests.Evaluators.Generic
{
    public class SimilarityEvaluatorTests
    {
        [Theory, AutoNSubstituteData]
        public void Should_Evaluate_Difference_Between_Two_Objects(
            PrimitiveEvaluable item1,
            PrimitiveEvaluable item2,
            SimilarityEvaluator<PrimitiveEvaluable> evaluator)
        {
            var expectedDistance = DistanceEvaluationHelper.EvaluateDistance(item1, item2);
            var actualDistance = evaluator.EvaluateDistance(item1, item2);

            actualDistance.Should().Be(expectedDistance);
        }

        [Theory, AutoNSubstituteData]
        public void Should_Evaluate_Difference_Between_Two_Objects_When_Left_One_Has_Null_Values(
            PrimitiveEvaluable item2,
            SimilarityEvaluator<PrimitiveEvaluable> evaluator)
        {
            var item1 = new PrimitiveEvaluable();

            var expectedDistance = DistanceEvaluationHelper.EvaluateDistance(item1, item2);
            var actualDistance = evaluator.EvaluateDistance(item1, item2);

            actualDistance.Should().Be(expectedDistance);
        }

        [Theory, AutoNSubstituteData]
        public void Should_Evaluate_Difference_Between_Two_Objects_When_Right_One_Has_Null_Values(
            PrimitiveEvaluable item1,
            SimilarityEvaluator<PrimitiveEvaluable> evaluator)
        {
            var item2 = new PrimitiveEvaluable();

            var expectedDistance = DistanceEvaluationHelper.EvaluateDistance(item1, item2);
            var actualDistance = evaluator.EvaluateDistance(item1, item2);

            actualDistance.Should().Be(expectedDistance);
        }

        [Theory, AutoNSubstituteData]
        public void When_Evaluating_Object_With_Unknown_Type_Should_Throw_Exception(
            UnknownTypeEvaluable item1,
            UnknownTypeEvaluable item2,
            SimilarityEvaluator<UnknownTypeEvaluable> evaluator)
        {
            var exception = Assert.Throws<Exception>(() => evaluator.EvaluateDistance(item1, item2));

            exception.Message.Should().Be("No inner evaluator was found for type System.Object.");
        }

        [Theory, AutoNSubstituteData]
        public void When_Evaluating_Two_Objects_With_List_Should_Calculate_Distance_01(
            SimilarityEvaluator<PrimitiveListEvaluable> evaluator)
        {
            var item1 = PrimitiveListEvaluable.Sample1;
            var item2 = PrimitiveListEvaluable.Sample2;

            evaluator.EvaluateDistance(item1, item2).Should().Be(5);
        }

        [Theory, AutoNSubstituteData]
        public void When_Evaluating_Two_Objects_With_List_Should_Calculate_Distance_02(
            SimilarityEvaluator<PrimitiveListEvaluable> evaluator)
        {
            var item1 = PrimitiveListEvaluable.Sample2;
            var item2 = PrimitiveListEvaluable.Sample1;

            evaluator.EvaluateDistance(item1, item2).Should().Be(5);
        }

        [Theory, AutoNSubstituteData]
        public void When_Evaluating_Two_Objects_With_List_Should_Calculate_Distance_03(
            SimilarityEvaluator<PrimitiveListEvaluable> evaluator)
        {
            var item1 = PrimitiveListEvaluable.Sample1;
            var item2 = PrimitiveListEvaluable.Sample4;

            evaluator.EvaluateDistance(item1, item2).Should().Be(11);
        }

        [Theory, AutoNSubstituteData]
        public void When_Evaluating_Two_Objects_With_List_Should_Calculate_Distance_04(
            SimilarityEvaluator<PrimitiveListEvaluable> evaluator)
        {
            var item1 = PrimitiveListEvaluable.Sample4;
            var item2 = PrimitiveListEvaluable.Sample1;

            evaluator.EvaluateDistance(item1, item2).Should().Be(11);
        }

        [Theory, AutoNSubstituteData]
        public void When_Evaluating_Two_Objects_With_List_Should_Calculate_Distance_05(
            SimilarityEvaluator<PrimitiveListEvaluable> evaluator)
        {
            var item1 = PrimitiveListEvaluable.Sample4;
            var item2 = PrimitiveListEvaluable.Sample4;

            evaluator.EvaluateDistance(item1, item2).Should().Be(0);
        }

        [Theory, AutoNSubstituteData]
        public void When_Evaluating_Two_Objects_With_List_Should_Calculate_Distance_06(
            SimilarityEvaluator<PrimitiveListEvaluable> evaluator)
        {
            var item1 = PrimitiveListEvaluable.Sample1;
            var item2 = PrimitiveListEvaluable.Sample3;

            evaluator.EvaluateDistance(item1, item2).Should().Be(4);
        }

        [Theory, AutoNSubstituteData]
        public void When_Evaluating_Two_Objects_With_List_Should_Calculate_Distance_07(
            SimilarityEvaluator<PrimitiveListEvaluable> evaluator)
        {
            var item1 = PrimitiveListEvaluable.Sample3;
            var item2 = PrimitiveListEvaluable.Sample1;

            evaluator.EvaluateDistance(item1, item2).Should().Be(4);
        }

        [Theory, AutoNSubstituteData]
        public void Should_Have_Primitive_Evaluators_When_Created(
            SimilarityEvaluator<PrimitiveEvaluable> evaluator)
        {
            evaluator.InnerEvaluators.ShouldBeEquivalentTo(SimilarityEvaluatorContainer.PrimitiveEvaluators);
        }

        [Theory, AutoNSubstituteData]
        public void Should_Override_Already_Added_InnerEvaluator(
            SimilarityEvaluator<PrimitiveEvaluable> evaluator)
        {
            var innerEvaluator = new Int32SimilarityEvaluator();

            evaluator.AddInnerEvaluator(innerEvaluator);

            evaluator.InnerEvaluators.Should().Contain(innerEvaluator);
        }

        [Theory, AutoNSubstituteData]
        public void Should_Override_Already_Added_InnerEvaluators(
            SimilarityEvaluator<PrimitiveEvaluable> evaluator)
        {
            var innerEvaluators = new SimilarityEvaluatorBase[]
            {
                new Int32SimilarityEvaluator(),
                new Int64SimilarityEvaluator()
            };

            evaluator.AddInnerEvaluators(innerEvaluators);

            evaluator.InnerEvaluators.Should().Contain(innerEvaluators);
        }
    }
}
