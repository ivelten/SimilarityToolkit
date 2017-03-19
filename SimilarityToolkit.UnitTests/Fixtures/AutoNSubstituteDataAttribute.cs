using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Ploeh.AutoFixture.Xunit2;
using SimilarityToolkit.Evaluators.UnitTests.Helpers;

namespace SimilarityToolkit.Evaluators.UnitTests.Fixtures
{
    public class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute()
            : base(new Fixture().Customize(new AutoConfiguredNSubstituteCustomization()))
        {
        }
    }
}
