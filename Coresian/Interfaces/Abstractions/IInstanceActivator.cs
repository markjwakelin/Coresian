using System;

namespace Coresian.Interfaces.Abstractions
{
    public interface IInstanceActivator
    {
        object Activate(Type type);

        object Activate(Type type, object[] constructorArguments);
    }
}