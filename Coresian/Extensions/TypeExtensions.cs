using System;
using System.Linq;

namespace Coresian.Extensions
{
    public static class TypeExtensions
    {
        public static bool CanBeCastAs(this Type thisType, Type givenType)
        {
            if (thisType == null)
                throw new ArgumentNullException(nameof(thisType));
            if(givenType == null)
                throw new ArgumentNullException(nameof(givenType));
            return givenType.IsAssignableFrom(thisType);
        }

        public static bool CanBeCastAs(this object thisObject, Type givenType)
        {
            if (thisObject == null)
                throw new ArgumentNullException(nameof(thisObject));
            return CanBeCastAs(thisObject.GetType(), givenType);
        }

        public static object GetDefault(this Type thisType)
        {
            if (thisType == null)
                throw new ArgumentNullException(nameof(thisType));
            return thisType.IsValueType // else #ifdef std2.0 type.GetTypeInfo().IsValueType
                ? Activator.CreateInstance(thisType)
                : null;
        }

        public static bool IsConstructedGenericOfOpenGeneric(this Type thisType, Type openGeneric)
        {
            ValidateOpenGenericArguments(thisType, openGeneric);

            return thisType.IsGenericType && thisType.IsConstructedGenericType && thisType.GetGenericTypeDefinition() == openGeneric;
        }

        public static bool ImplementsOpenGeneric(this Type thisType, Type openGeneric)
        {
            ValidateOpenGenericArguments(thisType, openGeneric);

            if (thisType.IsConstructedGenericOfOpenGeneric(openGeneric))
                return true;
            if (thisType.GetInterfaces().Any(i => i.IsConstructedGenericOfOpenGeneric(openGeneric)))
                return true;
            while (thisType.BaseType != null)
            {
                thisType = thisType.BaseType;
                if (thisType.IsConstructedGenericOfOpenGeneric(openGeneric))
                    return true;
            }

            return false;
        }

        private static void ValidateOpenGenericArguments(Type thisType, Type openGeneric)
        {
            if (thisType == null)
                throw new ArgumentNullException(nameof(thisType));
            if (openGeneric == null)
                throw new ArgumentNullException(nameof(openGeneric));
            if (!openGeneric.IsGenericTypeDefinition) // is ! open generic type
                throw new ArgumentException("Must be an open generic type", nameof(openGeneric));
        }
    }
}
