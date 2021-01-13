namespace DIES.Interfaces
{
    using System.Reflection;

    public interface IDependencyInjectionCriteria
    {
        Assembly TargetAssembly { get; }
        string ClassNameStartingWith { get; }
        string ClassNameEndingWith { get; }
        DependencyInjectionLifetimeScope LifetimeScope { get; }

        IDependencyInjectionCriteria FromAssembly(Assembly assembly);
        IDependencyInjectionCriteria StartingWith(string startingWith);
        IDependencyInjectionCriteria EndingWith(string endingWith);
        IDependencyInjectionCriteria WithScope(DependencyInjectionLifetimeScope lifetimeScope);
    }
}
