using System;
using Coresian.Providers;
using Xunit;

namespace Coresian.UnitTests.Providers
{
    public class GuidProviderUnitTests
    {
        [Fact]
        public void WhenIGetAGuidItIsNotEmpty()
        {
            var target = new GuidProvider();
            Assert.NotEqual(Guid.Empty, target.Create());
        }
    }
}
