using System;
using Coresian.Providers;
using Xunit;

namespace Coresian.UnitTests.Providers
{
    
    public class DateTimeProviderUnitTests
    {
        [Fact]
        public void WhenIGetTheLocalDateTimeItIsReturned()
        {
            var target = new DateTimeProvider();
            
            var timeBefore = DateTime.Now;
            var result = target.GetLocalTime();
            var timeAfter = DateTime.Now;

            Assert.InRange(result, timeBefore, timeAfter);
        }

        [Fact]
        public void WhenIGetTheUtcDateTimeItIsReturned()
        {
            var target = new DateTimeProvider();
            
            var timeBefore = DateTime.UtcNow;
            var result = target.GetUtcTime();
            var timeAfter = DateTime.UtcNow;

            Assert.InRange(result, timeBefore, timeAfter);
        }
        
    }
}
