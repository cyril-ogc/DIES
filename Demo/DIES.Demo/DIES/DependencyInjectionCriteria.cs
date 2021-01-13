namespace DIES
{
    using DIES.Interfaces;
    using System;
    using System.Reflection;

    public class DependencyInjectionCriteria : IDependencyInjectionCriteria
    {
        public Assembly TargetAssembly { get; private set; }
        public string ClassNameStartingWith { get; private set; }
        public string ClassNameEndingWith { get; private set; }
        public DependencyInjectionLifetimeScope LifetimeScope { get; private set; }

        public IDependencyInjectionCriteria FromAssembly(Assembly assembly)
        {
            TargetAssembly = assembly;

            return this;
        }

        public IDependencyInjectionCriteria StartingWith(string startingWith)
        {
            ClassNameStartingWith = startingWith;

            return this;
        }

        public IDependencyInjectionCriteria EndingWith(string endingWith)
        {
            ClassNameEndingWith = endingWith;

            return this;
        }

        public IDependencyInjectionCriteria WithScope(DependencyInjectionLifetimeScope lifetimeScope)
        {
            LifetimeScope = lifetimeScope;

            return this;
        }

        public DependencyInjectionCriteria()
        {
            TargetAssembly = Assembly.GetExecutingAssembly();
            ClassNameStartingWith = String.Empty;
            ClassNameEndingWith = String.Empty;
            LifetimeScope = DependencyInjectionLifetimeScope.Transient;
        }
    }
}
