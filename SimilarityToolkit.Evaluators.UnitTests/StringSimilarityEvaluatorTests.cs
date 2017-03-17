using FluentAssertions;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using Xunit;

namespace SimilarityToolkit.Evaluators.UnitTests
{
    public class StringSimilarityEvaluatorTests
    {
        [Theory, AutoNSubstituteInlineData("abc", "abc")]
        public void Similarity_Test_01(string item1, string item2, StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(item1, item2).Should().Be(0);
        }

        [Theory, AutoNSubstituteInlineData("abc", "abC")]
        public void Similarity_Test_02(string item1, string item2, StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(item1, item2).Should().Be(1);
        }

        [Theory, AutoNSubstituteInlineData("abc", "abC ")]
        public void Similarity_Test_03(string item1, string item2, StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(item1, item2).Should().Be(2);
        }

        [Theory, AutoNSubstituteInlineData("", "")]
        public void Similarity_Test_04(string item1, string item2, StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(item1, item2).Should().Be(0);
        }

        [Theory, AutoNSubstituteInlineData(null, "")]
        public void Similarity_Test_05(string item1, string item2, StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(item1, item2).Should().Be(0);
        }

        [Theory, AutoNSubstituteInlineData("", null)]
        public void Similarity_Test_06(string item1, string item2, StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(item1, item2).Should().Be(0);
        }

        [Theory, AutoNSubstituteInlineData(null, null)]
        public void Similarity_Test_07(string item1, string item2, StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(item1, item2).Should().Be(0);
        }

        [Theory, AutoNSubstituteInlineData(null, "abc")]
        public void Similarity_Test_08(string item1, string item2, StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(item1, item2).Should().Be(3);
        }

        [Theory, AutoNSubstituteInlineData("abc", null)]
        public void Similarity_Test_09(string item1, string item2, StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(item1, item2).Should().Be(3);
        }

        [Theory, AutoNSubstituteInlineData("", "abc")]
        public void Similarity_Test_10(string item1, string item2, StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(item1, item2).Should().Be(3);
        }

        [Theory, AutoNSubstituteInlineData("abc", "")]
        public void Similarity_Test_11(string item1, string item2, StringSimilarityEvaluator evaluator)
        {
            evaluator.EvaluateDistance(item1, item2).Should().Be(3);
        }
    }
}
