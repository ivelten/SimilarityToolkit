using Ploeh.AutoFixture.Idioms;
using SimilarityToolkit.Evaluators.Generic;
using SimilarityToolkit.Evaluators.UnitTests.Fixtures;
using Xunit;

namespace SimilarityToolkit.UnitTests.Evaluators.Generic
{
    public class EnumerableSimilarityEvaluatorTests
    {
        [Theory, AutoNSubstituteData]
        public void EnumerableSimilarityEvaluator_Constructor_Should_Guard_Its_Clause(GuardClauseAssertion assertion)
        {
            assertion.Verify(typeof(EnumerableSimilarityEvaluator<>).GetConstructors());
        }
    }
}
