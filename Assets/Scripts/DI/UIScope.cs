using System.Collections;
using System.Collections.Generic;
using VContainer;
using VContainer.Internal;
using VContainer.Unity;

public class UIScope : LifetimeScope
{
    private GameEventsDispatcher gameController;
    private IReadOnlyList<IGameEventListener> thisScopeGameEventListeners;
    protected override void Configure(IContainerBuilder builder)
    {
        RegisterUi(builder);
    }

    private void RegisterUi(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<GameUI>().AsSelf().AsImplementedInterfaces();
        builder.RegisterComponentInHierarchy<GameOverScreen>().AsSelf().AsImplementedInterfaces();


        builder.RegisterBuildCallback(container =>
        {
            var dispatchers = container.Resolve<IEnumerable<IScopeDispatcher>>();
            foreach (var dispatcher in dispatchers)
            {
                dispatcher.StartDispatching(container);
            }
        });

        builder.RegisterDisposeCallback(container =>
        {
            var dispatchers = container.Resolve<IEnumerable<IScopeDispatcher>>();
            foreach (var dispatcher in dispatchers)
            {
                dispatcher.StopDispatching(container);
            }
        });
    }
}
