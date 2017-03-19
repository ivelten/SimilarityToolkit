using FluentAssertions;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using Xunit;

namespace SimilarityToolkit.UnitTests.Evaluators
{
    public class StringSimilarityEvaluatorTests
    {
        [Theory, AutoNSubstituteData]
        public void Similarity_Test_01(StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance("abc", "abc").Should().Be(0);
        }

        [Theory, AutoNSubstituteData]
        public void Similarity_Test_02(StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance("abc", "abC").Should().Be(1);
        }

        [Theory, AutoNSubstituteData]
        public void Similarity_Test_03(StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance("abc", "abC ").Should().Be(2);
        }

        [Theory, AutoNSubstituteData]
        public void Similarity_Test_04(StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance("", "").Should().Be(0);
        }

        [Theory, AutoNSubstituteData]
        public void Similarity_Test_05(StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(null, "").Should().Be(0);
        }

        [Theory, AutoNSubstituteData]
        public void Similarity_Test_06(StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance("", null).Should().Be(0);
        }

        [Theory, AutoNSubstituteData]
        public void Similarity_Test_07(StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(null, null).Should().Be(0);
        }

        [Theory, AutoNSubstituteData]
        public void Similarity_Test_08(StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(null, "abc").Should().Be(3);
        }

        [Theory, AutoNSubstituteData]
        public void Similarity_Test_09(StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance("abc", null).Should().Be(3);
        }

        [Theory, AutoNSubstituteData]
        public void Similarity_Test_10(StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance("", "abc").Should().Be(3);
        }

        [Theory, AutoNSubstituteData]
        public void Similarity_Test_11(StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance("abc", "").Should().Be(3);
        }
    }
}
