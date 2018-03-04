using Coresian.Interfaces.Factories;

namespace Coresian.Factory
{
    public class NewableFactory : INewableFactory
    {
        public T New<T>() where T : new()
        {
            return new T();
        }
    }
}