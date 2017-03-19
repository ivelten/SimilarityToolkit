using System.Collections.Generic;

namespace SimilarityToolkit.Evaluators.UnitTests.Helpers.Evaluables
{
    public class PrimitiveListEvaluable
    {
        public List<string> StringList { get; set; }

        public static PrimitiveListEvaluable Sample1 => new PrimitiveListEvaluable
        {
            StringList = new List<string> { "one", "two", "three" }
        };

        public static PrimitiveListEvaluable Sample2 => new PrimitiveListEvaluable
        {
            StringList = new List<string> { "two", "one", "four" }
        };

        public static PrimitiveListEvaluable Sample3 => new PrimitiveListEvaluable
        {
            StringList = new List<string> { "three", "four", "two", "one" }
        };

        public static PrimitiveListEvaluable Sample4 => new PrimitiveListEvaluable
        {
            StringList = null
        };
    }
}
