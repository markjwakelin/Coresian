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
            new object[] { typeof(TestGenericInOutInterfaceImplementation), typeof(ITestInterface), true },
            new object[] { typeof(TestGenericInOutInterfaceImplementation), typeof(ITestGenericInOutInterface<TestObject>), true },
            new object[] { typeof(TestGenericInOutInterfaceImplementation), typeof(ITestGenericInInterface<TestObject>), true },
            new object[] { typeof(TestGenericInOutInterfaceImplementation), typeof(ITestGenericOutInterface<TestObject>), true },
            new object[] { typeof(TestGenericInOutInterfaceImplementation), typeof(ITestGenericInOutInterface<object>), false },
            new object[] { typeof(TestGenericInOutInterfaceImplementation), typeof(ITestGenericInInterface<object>), false },
            new object[] { typeof(TestGenericInOutInterfaceImplementation), typeof(ITestGenericOutInterface<object>), true },
            new object[] { typeof(TestGenericInOutInterfaceImplementation), typeof(ITestGenericInOutInterface<>), false },
        };

        [Theory]
        [MemberData(nameof(TypeTestData), MemberType = typeof(TypeExtensionsUnitTests))]
        public void Type_CanBeCastAsWorksAsExpected(Type givenType, Type targetType, bool expectedResult)
        {
            Assert.Equal(expectedResult, givenType.CanBeCastAs(targetType));
        }


        public static List<object[]> GetDefaultTestData = new List<object[]>()
        {
            new object[] { typeof(string), null },
            new object[] { typeof(int), 0 },
            new object[] { typeof(bool), false },
            new object[] { typeof(object), null },
        };

        [Theory]
        [MemberData(nameof(GetDefaultTestData), MemberType = typeof(TypeExtensionsUnitTests))]
        public void Type_GetDefaultWorksAsExpected(Type givenType, object expectedResult)
        {
            Assert.Equal(expectedResult, givenType.GetDefault());
        }

        public static List<object[]> InstanceTestData = new List<object[]>()
        {
            new[] { new object(), typeof(object), true },
            new[] { new object(), typeof(Type), false },
            new object[] { typeof(object), typeof(object), true },
            new object[] { new TestObject(), typeof(object), true },
            new[] { new object(), typeof(TestObject), false },
            new object[] { new TestGenericInOutInterfaceImplementation(), typeof(ITestInterface), true },
            new object[] { new TestGenericInOutInterfaceImplementation(), typeof(ITestGenericInOutInterface<TestObject>), true },
            new object[] { new TestGenericInOutInterfaceImplementation(), typeof(ITestGenericInInterface<TestObject>), true },
            new object[] { new TestGenericInOutInterfaceImplementation(), typeof(ITestGenericOutInterface<TestObject>), true },
            new object[] { new TestGenericInOutInterfaceImplementation(), typeof(ITestGenericInOutInterface<object>), false },
            new object[] { new TestGenericInOutInterfaceImplementation(), typeof(ITestGenericInInterface<object>), false },
            new object[] { new TestGenericInOutInterfaceImplementation(), typeof(ITestGenericOutInterface<object>), true },
            new object[] { new TestGenericInOutInterfaceImplementation(), typeof(ITestGenericInOutInterface<>), false },
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

        public interface ITestGenericInOutInterface<T>
        {
            T Thing { get; set; }
        }
        
        public interface ITestGenericOutInterface<out T>
        {
            T Thing { get; }
        }
        
        public interface ITestGenericInInterface<in T>
        {
            void Whatever(T thing);
        }

        public class TestGenericInOutInterfaceImplementation : ITestInterface, ITestGenericInOutInterface<TestObject>, ITestGenericOutInterface<TestObject>, ITestGenericInInterface<TestObject>
        {
            public TestGenericInOutInterfaceImplementation()
            {
                Thing = new TestObject();
            }

            public TestObject Thing { get; set; }
            
            public void Whatever(TestObject thing)
            {
            }
        }
    }
}
