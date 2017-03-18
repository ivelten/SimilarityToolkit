using FluentAssertions;
using SimilarityToolkit.Evaluators.Abstractions;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using SimilarityToolkit.Evaluators.UnitTests.Helpers;
using System;
using Xunit;

namespace SimilarityToolkit.Evaluators.UnitTests
{
    public class ObjectEvaluatorTests
    {
        [Theory, AutoNSubstituteData]
        public void Should_Evaluate_Difference_Between_Two_Objects(
            PrimitiveEvaluableObject item1,
            PrimitiveEvaluableObject item2,
            ObjectEvaluator<PrimitiveEvaluableObject> evaluator)
        {
            var expectedDistance = DistanceEvaluationHelper.EvaluateDistance(item1, item2);
            var actualDistance = evaluator.EvaluateDistance(item1, item2);

            actualDistance.Should().Be(expectedDistance);
        }

        [Theory, AutoNSubstituteData]
        public void Should_Evaluate_Difference_Between_Two_Objects_When_Left_One_Has_Null_Values(
        PrimitiveEvaluableObject item2,
        ObjectEvaluator<PrimitiveEvaluableObject> evaluator)
        {
            var item1 = new PrimitiveEvaluableObject();
            var expectedDistance = DistanceEvaluationHelper.EvaluateDistance(item1, item2);
            var actualDistance = evaluator.EvaluateDistance(item1, item2);

            actualDistance.Should().Be(expectedDistance);
        }

        [Theory, AutoNSubstituteData]
        public void Should_Evaluate_Difference_Between_Two_Objects_When_Right_One_Has_Null_Values(
            PrimitiveEvaluableObject item1,
            ObjectEvaluator<PrimitiveEvaluableObject> evaluator)
        {
            var item2 = new PrimitiveEvaluableObject();
            var expectedDistance = DistanceEvaluationHelper.EvaluateDistance(item1, item2);
            var actualDistance = evaluator.EvaluateDistance(item1, item2);

            actualDistance.Should().Be(expectedDistance);
        }

        [Theory, AutoNSubstituteData]
        public void When_Evaluating_Object_With_Unknown_Type_Should_Throw_Exception(
            UnknownTypeEvaluableObject item1,
            UnknownTypeEvaluableObject item2,
            ObjectEvaluator<UnknownTypeEvaluableObject> evaluator)
        {
            var exception = Assert.Throws<Exception>(() => evaluator.EvaluateDistance(item1, item2));

            exception.Message.Should().Be($"No inner evaluator was found for type System.Object.");
        }

        [Theory, AutoNSubstituteData]
        public void Should_Have_Primitive_Evaluators_When_Created(
            ObjectEvaluator<PrimitiveEvaluableObject> evaluator)
        {
            evaluator.InnerEvaluators.ShouldBeEquivalentTo(EvaluatorContainer.PrimitiveEvaluators);
        }

        [Theory, AutoNSubstituteData]
        public void Should_Override_Already_Added_InnerEvaluator(
            ObjectEvaluator<PrimitiveEvaluableObject> evaluator)
        {
            var innerEvaluator = new Int32SimilarityEvaluator();

            evaluator.AddInnerEvaluator(innerEvaluator);

            evaluator.InnerEvaluators.Should().Contain(innerEvaluator);
        }

        [Theory, AutoNSubstituteData]
        public void Should_Override_Already_Added_InnerEvaluators(
            ObjectEvaluator<PrimitiveEvaluableObject> evaluator)
        {
            var innerEvaluators = new SimilarityEvaluator[]
            {
                new Int32SimilarityEvaluator(),
                new Int64SimilarityEvaluator()
            };

            evaluator.AddInnerEvaluators(innerEvaluators);

            evaluator.InnerEvaluators.Should().Contain(innerEvaluators);
        }
    }
}
