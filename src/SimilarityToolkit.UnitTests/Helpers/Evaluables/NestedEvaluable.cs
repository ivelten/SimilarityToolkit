namespace SimilarityToolkit.UnitTests.Helpers.Evaluables
{
    public class NestedEvaluable
    {
        public NestedEvaluable InnerEvaluable { get; set; }

        public string StringProperty { get; set; }

        public static NestedEvaluable Sample1 => new NestedEvaluable
        {
            InnerEvaluable = null,
            StringProperty = "abc"
        };

        public static NestedEvaluable Sample2 => new NestedEvaluable
        {
            InnerEvaluable = new NestedEvaluable
            {
                InnerEvaluable = null,
                StringProperty = "abc"
            },
            StringProperty = "abc"
        };
    }
}
