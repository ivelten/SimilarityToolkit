using System.Collections.Generic;

namespace SimilarityToolkit.Evaluators.UnitTests.Helpers.Evaluables
{
    public class PrimitiveEnumerableEvaluable
    {
        public List<string> StringList { get; set; }

        public string[] StringArray { get; set; }

        public Dictionary<string, string> StringDictionary { get; set; }
    }
}
