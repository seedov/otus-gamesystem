using System.Collections.Generic;
using Lessons.Architecture.VContainer;
using UnityEditor.Search;
using VContainer;
using VContainer.Unity;

public class TurelLifetimeScope : LifetimeScope
{
    private IEnumerable<IScopeDispatcher> dispatchers;
    protected override void Configure(IContainerBuilder builder)
    {
        RegisterTurel(builder);
        RegisterGameCycle(builder);
        builder.RegisterBuildCallback(container =>
        {

            dispatchers = container.Resolve<IEnumerable<IScopeDispatcher>>();
            foreach (var dispathcer in dispatchers)
            {
                dispathcer.StartDispatching(container);
            }
        });

        builder.RegisterDisposeCallback(container =>
        {
            foreach (var dispathcer in dispatchers)
            {
                dispathcer.StopDispatching(container);
            }
        });
    }

    private void RegisterTurel(IContainerBuilder builder)
    {
        builder.RegisterComponent(GetComponentInChildren<Turel>()).AsImplementedInterfaces();
        builder.RegisterComponent(GetComponentInChildren<BulletsSpawner>()).AsImplementedInterfaces();
    }

    private void RegisterGameCycle(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<PausableTickersDispatcher>();
        builder.Register<GameEventsDispatcher>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
    }
}
