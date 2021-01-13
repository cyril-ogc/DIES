namespace DIES
{
    using DIES.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddExtendedScopeProfile(this IServiceCollection serviceCollection, Action<IDependencyInjectionExtendedProfile> extendedProfile)
        {
            IDependencyInjectionExtendedProfile dependencyInjectionExtendedProfile = new DependencyInjectionExtendedProfile(serviceCollection, new DependencyInjectionCriteria());
            extendedProfile(dependencyInjectionExtendedProfile);

            return serviceCollection;
        }
    }
}
