using System;
using FluentAssertions;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using SimilarityToolkit.Evaluators.UnitTests.Helpers;
using Xunit;

namespace SimilarityToolkit.Evaluators.UnitTests
{
    public class ObjectEvaluatorTests
    {
        [Theory, AutoNSubstituteData]
        public void Should_Evaluate_Difference_Between_Two_Objects(
            PrimitivesEvaluableObject item1,
            PrimitivesEvaluableObject item2,
            ObjectEvaluator<PrimitivesEvaluableObject> evaluator)
        {
            var expectedDistance = GetExpectedDistance(item1, item2);
            var actualDistance = evaluator.EvaluateDistance(item1, item2);

            actualDistance.Should().Be(expectedDistance);
        }

        private decimal GetExpectedDistance(PrimitivesEvaluableObject item1, PrimitivesEvaluableObject item2)
        {
            var distance = 0M;

            // TODO: calculate correct distance

            return distance;
        }
    }
}
