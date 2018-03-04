namespace Coresian.Interfaces.Factories
{
    public interface INewableFactory
    {
        T New<T>() where T : new();
    }
}