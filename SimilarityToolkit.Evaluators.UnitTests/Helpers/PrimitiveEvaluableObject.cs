using System;

namespace SimilarityToolkit.Evaluators.UnitTests.Helpers
{
    public class PrimitiveEvaluableObject
    {
        public string StringProperty { get; set; }

        public byte ByteProperty { get; set; }

        public byte? NullableByteProperty { get; set; }

        public short Int16Property { get; set; }

        public short? NullableInt16Property { get; set; }

        public int Int32Property { get; set; }

        public int? NullableInt32Property { get; set; }

        public long Int64Property { get; set; }

        public long? NullableInt64Property { get; set; }

        public float SingleProperty { get; set; }

        public float? NullableSingleProperty { get; set; }

        public double DoubleProperty { get; set; }

        public double? NullableDoubleProperty { get; set; }

        public decimal DecimalProperty { get; set; }

        public decimal? NullableDecimalProperty { get; set; }

        public DateTime DateTimeProperty { get; set; }

        public DateTime? NullableDateTimeProperty { get; set; }
    }
}
