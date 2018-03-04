using Coresian.Factory;
using Xunit;

namespace Coresian.UnitTests.Factories
{
    public class NewableFactoryUnitTests
    {
        [Fact]
        public void WhenICreateANewableItIsCreated()
        {
            var target = new NewableFactory();
            var thing = target.New<object>();
            Assert.IsType<object>(thing);
        }
    }
}