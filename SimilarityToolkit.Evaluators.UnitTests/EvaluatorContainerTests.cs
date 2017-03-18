using FluentAssertions;
using Xunit;

namespace SimilarityToolkit.Evaluators.UnitTests
{
    public class EvaluatorContainerTests
    {
        [Fact]
        public void Should_Give_Primitive_Evaluator()
        {
            var evaluator = SimilarityEvaluatorContainer.GetPrimitiveEvaluator<int>();

            evaluator.Should().NotBeNull();
            evaluator.Should().BeOfType(typeof(Int32SimilarityEvaluator));
        }

        [Fact]
        public void Should_Return_Null_For_Non_Existent_Evaluator()
        {
            var evaluator = SimilarityEvaluatorContainer.GetPrimitiveEvaluator<object>();

            evaluator.Should().BeNull();
        }
    }
}
