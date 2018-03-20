using System;
using System.Collections.Generic;
using System.Text;
using Coresian.Abstractions;
using Xunit;

namespace Coresian.UnitTests.Abstractions
{
    public static class ConverterUnitTests
    {
        [Theory, AutoNSubstituteData]
        public static void WhenConvertingToBase64TheResultIsTheSame1(byte[] content)
        {
            var expectedResult = Convert.ToBase64String(content);
            var converter = new Converter();
            var result = converter.ToBase64(content);
            Assert.Equal(expectedResult, result);
        }

        [Theory, AutoNSubstituteData]
        public static void WhenConvertingToBase64TheResultIsTheSame2(byte[] content)
        {
            var expectedResult = Convert.ToBase64String(content, 1, 1);
            var converter = new Converter();
            var result = converter.ToBase64(content, 1, 1);
            Assert.Equal(expectedResult, result);
        }

        [Theory, AutoNSubstituteData]
        public static void WhenConvertingToBase64TheResultIsTheSame3(byte[] content)
        {
            var expectedResult = Convert.ToBase64String(content, 0, 3, Base64FormattingOptions.InsertLineBreaks);
            var converter = new Converter();
            var result = converter.ToBase64(content, 0, 3, Base64FormattingOptions.InsertLineBreaks);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public static void WhenConvertingFromBase64TheResultIsCorrect()
        {
            var expectedResult = new byte[]
            {
                12,
                44,
                98,
                34,
                51,
                42,
                98,
                23,
                43
            };
            var base64String = Convert.ToBase64String(expectedResult);
            var converter = new Converter();
            var result = converter.FromBase64(base64String);
            Assert.Equal(expectedResult, result);
        }
    }
}
