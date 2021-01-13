namespace DIES.Interfaces
{
    using System;

    public interface IDependencyInjectionExtendedProfile
    {
        void BindAllInterfaces();
        IDependencyInjectionExtendedProfile WithCriteria(Action<IDependencyInjectionCriteria> dependcyInjectionCriteria);
    }
}
