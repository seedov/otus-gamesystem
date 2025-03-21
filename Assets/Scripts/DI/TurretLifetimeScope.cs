using System.Collections.Generic;
using Lessons.Architecture.VContainer;
using UnityEngine;
using VContainer;
using VContainer.Unity;
public class TurretLifetimeScope : LifetimeScope
{
    private IEnumerable<IScopeDispatcher> dispatchers;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(GetComponent<Turel>()).AsImplementedInterfaces();
        builder.RegisterComponent(GetComponentInChildren<BulletsSpawner>()).AsSelf().AsImplementedInterfaces();
        builder.RegisterBuildCallback(container =>
        {
            dispatchers = container.Resolve<IEnumerable<IScopeDispatcher>>();
            foreach (var dispatcher in dispatchers) 
                dispatcher.StartDispatching(container);
        });
        builder.RegisterDisposeCallback(container =>
        {
            foreach (var dispatcher in dispatchers)
                dispatcher.StopDispatching(container);
        });
    }

    
}
