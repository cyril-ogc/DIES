# DIES
DependencyInjection Extended Scope

# What is it for?
Imagine you have several interfaces you want to implement with DependencyInjection from Microsoft at once?

DIES lets you define a scope profile with different types of criteria (as it exists in multiple other IoC containers yet):
* Target assembly (by default: `ExecutingAssembly`)
* Class name starting by (by default: `Empty`)
* Class name ending by (by default: `Empty`)
* Lifefime scope (by default: `Transient`)

# Usage example
You want to register all the services implementations ending by "Service"?

Instead of register each class into the container, you can do as the following example:

```csharp
serviceCollection.AddExtendedScopeProfile(profile =>
    profile.WithCriteria(criteria =>
        criteria.FromAssembly(Assembly.GetAssembly(typeof(FooService)))
            .EndingWith("Service")
    ).BindAllInterfaces()
);
```

# Compatibility 

Only tested with `.NET Core 3.1` and `.NET Framework 4.6` so far.

# Miscellaneous notes

I think it can be widelly improved. I'd love to receive suggestions about it.

Feel free to fork it if you like it. 
