using System;
using System.Collections.Generic;
using Coresian.Abstractions;
using Xunit;

namespace Coresian.UnitTests.Abstractions
{
    public class TypeConverterUnitTests
    {
        public static List<object[]> ConversionTestData = new List<object[]>()
        {
            new object[] { 123, typeof(string), "123" },
            new object[] { "123", typeof(int), 123 },
        };

        [Theory]
        [MemberData(nameof(ConversionTestData), MemberType = typeof(TypeConverterUnitTests))]
        public void Type_CanBeCastAsWorksAsExpected(object input, Type targetType, object expectedOutcome)
        {
            var target = new TypeConverter();

            var result = target.Convert(targetType, input);

            Assert.Equal(expectedOutcome, result);
        }
    }
}
