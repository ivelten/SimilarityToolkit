using System.Collections.Generic;

namespace SimilarityToolkit.Evaluators.UnitTests.Helpers.Evaluables
{
    public class ListEvaluable
    {
        public List<string> StringList { get; set; }

        public static ListEvaluable Sample1 => new ListEvaluable
        {
            StringList = new List<string> { "one", "two", "three" }
        };

        public static ListEvaluable Sample2 => new ListEvaluable
        {
            StringList = new List<string> { "two", "one", "four" }
        };

        public static ListEvaluable Sample3 => new ListEvaluable
        {
            StringList = new List<string> { "three", "four", "two", "one" }
        };

        public static ListEvaluable Sample4 => new ListEvaluable
        {
            StringList = null
        };
    }
}
