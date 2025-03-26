using Lessons.Architecture.VContainer;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]
    private InputConfig keyboardKonfig;    
    [SerializeField]
    private WeaponConfig weaponConfig;

    private PausableTickersDispatcher gameLoopManager;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GameEventsDispatcher>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        builder.Register<GameController>(Lifetime.Singleton);
        RegisterConfigs(builder);

        builder.Register<MoveController>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        builder.Register<KeyboardInput>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

        builder.RegisterComponentInHierarchy<MoveComponent>().AsSelf().AsImplementedInterfaces();
        builder.RegisterComponentInHierarchy<HPComponent>().As<IHealthComponent>().As<IGameEventListener>();


        builder.RegisterEntryPoint<PausableTickersDispatcher>().AsSelf();


        builder.RegisterBuildCallback(container =>
        {
            gameLoopManager = container.Resolve<PausableTickersDispatcher>();
            gameLoopManager.StartDispatching(container);
        });
        builder.RegisterDisposeCallback(container =>
        {
            gameLoopManager.StopDispatching(container);
        });

        builder.Register<Pool<Bullet>>(Lifetime.Singleton).AsSelf();

    }


    private void RegisterConfigs(IContainerBuilder builder)
    {
        builder.RegisterInstance(weaponConfig.BulletsConfig);
        builder.RegisterInstance(keyboardKonfig.KeyboardInputConfig).As<IKeyboardInputConfig>();

    }
}
