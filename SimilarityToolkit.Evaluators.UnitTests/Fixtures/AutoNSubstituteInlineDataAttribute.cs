using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace SimilarityToolkit.Evaluators.UnitTests.Fixtures
{
    public class AutoNSubstituteInlineDataAttribute : CompositeDataAttribute
    {
        public AutoNSubstituteInlineDataAttribute(params object[] values) 
            : base(new InlineDataAttribute(values), new AutoNSubstituteDataAttribute())
        {
        }
    }
}
