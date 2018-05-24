using System;
using Coresian.Interfaces.Abstractions;

namespace Coresian.Abstractions
{
    public class TypeConverter : ITypeConverter
    {
        public object Convert(Type type, object value)
        {
            return System.Convert.ChangeType(value, type);
        }
    }
}