using System;

namespace SimilarityToolkit.Evaluators.UnitTests.Helpers.Evaluables
{
    public class PrimitiveEvaluable
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

        public static PrimitiveEvaluable Sample1 => new PrimitiveEvaluable
        {
            ByteProperty = 1,
            DateTimeProperty = new DateTime(2016, 1, 1),
            DecimalProperty = 16m,
            DoubleProperty = 1.9,
            Int16Property = 52,
            Int32Property = 79,
            Int64Property = 57987,
            SingleProperty = 798.7f
        };

        public static PrimitiveEvaluable Sample2 => new PrimitiveEvaluable
        {
            ByteProperty = 1,
            DateTimeProperty = new DateTime(2016, 2, 24),
            DecimalProperty = 16m,
            DoubleProperty = 1.9,
            Int16Property = 52,
            Int32Property = 79,
            Int64Property = 37,
            SingleProperty = 798.7f,
            NullableByteProperty = 252,
            StringProperty = "abc",
            NullableDateTimeProperty = new DateTime(2017, 11, 20, 1, 32, 3),
            NullableDecimalProperty = 78.266m,
            NullableDoubleProperty = 798.987987,
            NullableInt16Property = 1577,
            NullableInt32Property = 89,
            NullableInt64Property = 21,
            NullableSingleProperty = 477
        };
    }
}
