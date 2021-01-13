namespace DIES
{
    using DIES.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DependencyInjectionExtendedProfile : IDependencyInjectionExtendedProfile
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IDependencyInjectionCriteria _dependencyInjectionCriteria;

        public IEnumerable<Type> excludedInterfaces => new HashSet<Type>
        {
            typeof(IDependencyInjectionExtendedProfile),
            typeof(IDependencyInjectionCriteria)
        };

        public DependencyInjectionExtendedProfile(IServiceCollection serviceCollection, IDependencyInjectionCriteria dependencyInjectionCriteria)
        {
            _serviceCollection = serviceCollection;
            _dependencyInjectionCriteria = dependencyInjectionCriteria;
        }

        public void BindAllInterfaces() => Bind(x => x.Name.StartsWith(_dependencyInjectionCriteria.ClassNameStartingWith) && x.Name.EndsWith(_dependencyInjectionCriteria.ClassNameEndingWith));

        public IDependencyInjectionExtendedProfile WithCriteria(Action<IDependencyInjectionCriteria> dependencyInjectionCriteria)
        {
            dependencyInjectionCriteria(_dependencyInjectionCriteria);

            return this;
        }

        #region Private method(s)

        private IServiceCollection Bind(Func<Type, bool> whereClause)
        {
            var implementationTypes = _dependencyInjectionCriteria.TargetAssembly.GetTypes().Where(x => x.IsClass && whereClause(x));

            foreach (var implementationType in implementationTypes)
                foreach (var interfaceType in implementationType?.GetInterfaces())
                    if (!excludedInterfaces.Any(x => x == interfaceType))
                        AddScope(interfaceType, implementationType);

            return _serviceCollection;
        }

        private void AddScope(Type interfaceType, Type implementationType)
        {
            switch (_dependencyInjectionCriteria.LifetimeScope)
            {
                case DependencyInjectionLifetimeScope.Scoped:
                    _serviceCollection.AddScoped(interfaceType, implementationType);
                    break;
                case DependencyInjectionLifetimeScope.Transient:
                    _serviceCollection.AddTransient(interfaceType, implementationType);
                    break;
                case DependencyInjectionLifetimeScope.Singleton:
                    _serviceCollection.AddSingleton(interfaceType, implementationType);
                    break;
            }
        }

        #endregion
    }
}
