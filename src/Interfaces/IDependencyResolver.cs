namespace DIES.Interfaces
{
    public interface IDependencyResolver
    {
        TService GetService<TService>();
    }
}
