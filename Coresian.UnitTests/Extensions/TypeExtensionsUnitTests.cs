using System;
using System.Collections.Generic;
using Coresian.Extensions;
using Xunit;

namespace Coresian.UnitTests.Extensions
{
    public class TypeExtensionsUnitTests
    {

        [Fact]
        public void NullTypeCanBeCastAsObjectThrowsArgumentException()
        {
            try
            {
                ((Type) null).CanBeCastAs(typeof(object));
            }
            catch (ArgumentNullException ane)
            {
                Assert.Equal("thisType", ane.ParamName);
            }
        }

        [Fact]
        public void NullInstanceCanBeCastAsObjectThrowsArgumentException()
        {
            try
            {
                ((object) null).CanBeCastAs(typeof(object));
            }
            catch (ArgumentNullException ane)
            {
                Assert.Equal("thisObject", ane.ParamName);
            }
        }
        
        [Fact]
        public void ObjectTypeCanBeCastAsNullThrowsArgumentException()
        {
            try
            {
                typeof(object).CanBeCastAs(null);
            }
            catch (ArgumentNullException ane)
            {
                Assert.Equal("givenType", ane.ParamName);
            }
        }
        
        [Fact]
        public void ObjectInstanceCanBeCastAsNullThrowsArgumentException()
        {
            try
            {
                new object().CanBeCastAs(null);
            }
            catch (ArgumentNullException ane)
            {
                Assert.Equal("givenType", ane.ParamName);
            }
        }
    }
}
