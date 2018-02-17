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

        public static List<object[]> TypeTestData = new List<object[]>()
        {
            new object[] { typeof(object), typeof(object), true },
            new object[] { typeof(object), typeof(Type), false },
            new object[] { typeof(Type), typeof(object), true },
            new object[] { typeof(TestObject), typeof(object), true },
            new object[] { typeof(object), typeof(TestObject), false },
            new object[] { typeof(TestInterfaceImplementation), typeof(ITestInterface), true },
            new object[] { typeof(TestInterfaceImplementation), typeof(ITestInterface<TestObject>), true },
            new object[] { typeof(TestInterfaceImplementation), typeof(ITestInterface<object>), false },
        };
        
        [Theory]
        [MemberData(nameof(TypeTestData), MemberType = typeof(TypeExtensionsUnitTests))]
        public void Type_CanBeCastAsWorksAsExpected(Type givenType, Type targetType, bool expectedResult)
        {
            Assert.Equal(expectedResult, givenType.CanBeCastAs(targetType));
        }
     
        public static List<object[]> InstanceTestData = new List<object[]>()
        {
            new[] { new object(), typeof(object), true },
            new[] { new object(), typeof(Type), false },
            new object[] { typeof(object), typeof(object), true },
            new object[] { new TestObject(), typeof(object), true },
            new[] { new object(), typeof(TestObject), false },
            new object[] { new TestInterfaceImplementation(), typeof(ITestInterface), true },
            new object[] { new TestInterfaceImplementation(), typeof(ITestInterface<TestObject>), true },
            new object[] { new TestInterfaceImplementation(), typeof(ITestInterface<object>), false },
        };
        
        [Theory]
        [MemberData(nameof(InstanceTestData), MemberType = typeof(TypeExtensionsUnitTests))]
        public void Instance_CanBeCastAsWorksAsExpected(object givenObject, Type targetType, bool expectedResult)
        {
            Assert.Equal(expectedResult, givenObject.CanBeCastAs(targetType));
        }
        
        public class TestObject
        {
            
        }

        public interface ITestInterface
        {
            
        }

        public interface ITestInterface<out T>
        {
            T Thing { get; }
        }

        public class TestInterfaceImplementation : ITestInterface, ITestInterface<TestObject>
        {
            public TestInterfaceImplementation()
            {
                Thing = new TestObject();
            }

            public TestObject Thing { get; }
        }
    }
}
