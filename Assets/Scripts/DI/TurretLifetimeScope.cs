using System.Collections.Generic;
using Lessons.Architecture.VContainer;
using UnityEngine;
using VContainer;
using VContainer.Unity;
public class TurretLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(GetComponent<Turel>()).AsImplementedInterfaces();
        builder.RegisterComponent(GetComponentInChildren<BulletsSpawner>()).AsSelf().AsImplementedInterfaces();
        builder.RegisterBuildCallback(container =>
        {
            var dispatchers = container.Resolve<IEnumerable<IScopeDispatcher>>();
            foreach (var dispatcher in dispatchers) 
                dispatcher.StartDispatching(container);
        });
        builder.RegisterDisposeCallback(container =>
        {
            var dispatchers = container.Resolve<IEnumerable<IScopeDispatcher>>();
            foreach (var dispatcher in dispatchers)
                dispatcher.StopDispatching(container);
        });
    }

    
}
