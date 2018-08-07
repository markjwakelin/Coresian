using System;
using Coresian.Interfaces.Abstractions;

namespace Coresian.Abstractions
{
    public class InstanceActivator : IInstanceActivator
    {
        public object Activate(Type type)
        {
            return Activator.CreateInstance(type);
        }

        public object Activate(Type type, object[] constructorArguments)
        {
            return Activator.CreateInstance(type, constructorArguments);
        }
    }
}