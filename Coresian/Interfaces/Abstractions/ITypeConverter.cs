using System;

namespace Coresian.Interfaces.Abstractions
{
    public interface ITypeConverter
    {
        object Convert(Type type, object value);
    }
}