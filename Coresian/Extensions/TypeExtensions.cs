using System;

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
    }
}
