using System;
using System.Collections.Generic;
using Xunit;

namespace Coresian.UnitTests.Extensions
{
    public class EnumerableTExtensionsUnitTests
    {
        [Theory, AutoNSubstituteData]
        public void ForEachWorks(List<string> enumerable)
        {
            var result = new List<string>();
            enumerable.ForEach(x => result.Add(x));
            Assert.NotEmpty(result);
            Assert.Equal(enumerable.Count, result.Count);
            foreach(var r in enumerable)
                Assert.Contains(result, x => x == r);
        }
        
        [Theory, AutoNSubstituteData]
        public void ForEachWithExceptionWorks(List<string> enumerable)
        {
            var result = new List<string>();
            Action action = () => enumerable.ForEach(x => throw new Exception());
            Assert.Throws<Exception>(action);
        }
    }
}
