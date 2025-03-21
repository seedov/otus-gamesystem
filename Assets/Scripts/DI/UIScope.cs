using System.Collections;
using System.Collections.Generic;
using VContainer;
using VContainer.Internal;
using VContainer.Unity;

public class UIScope : LifetimeScope
{
    private IEnumerable<IScopeDispatcher> dispatchers;
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
            dispatchers = container.Resolve<IEnumerable<IScopeDispatcher>>();
            foreach (var dispatcher in dispatchers)
            {
                dispatcher.StartDispatching(container);
            }
        });

        builder.RegisterDisposeCallback(container =>
        {
            foreach (var dispatcher in dispatchers)
            {
                dispatcher.StopDispatching(container);
            }
        });
    }
}
