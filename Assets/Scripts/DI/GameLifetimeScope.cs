
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Lessons.Architecture.VContainer
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private InputConfig keyboardKonfig;
        [SerializeField]
        private WeaponConfig weaponConfig;
        [SerializeField]
        private Bullet bulletPrefab;


        private IEnumerable<IScopeDispatcher> dispatchers;

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterConfigs(builder);

            builder.Register<MoveController>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.Register<KeyboardInput>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            RegisterPlayer(builder);

            RegisterBullets(builder);

            //           RegisterTurel(builder);

            builder.Register<GameController>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();

            RegisterGameCycle(builder);

            RegisterUi(builder);

            builder.RegisterBuildCallback(container =>
            {

                dispatchers = container.Resolve<IEnumerable<IScopeDispatcher>>();
                foreach(var dispathcer in dispatchers)
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

        private void RegisterBullets(IContainerBuilder builder)
        {
            builder.Register<Pool<Bullet>>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
            builder.RegisterFactory<Bullet>(objectResolver =>
            {
                return () =>
                {
                    var bullet = objectResolver.Instantiate(bulletPrefab);
                    return bullet;
                };
            }, Lifetime.Singleton);
        }

        private void RegisterGameCycle(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<PausableTickersDispatcher>();
            builder.Register<GameEventsDispatcher>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        }

        private void RegisterTurel(IContainerBuilder builder)
        {
            builder.RegisterComponent(GetComponentInChildren<Turel>()).AsImplementedInterfaces();
            builder.RegisterComponent(GetComponentInChildren<BulletsSpawner>()).AsImplementedInterfaces();
        }

        private void RegisterUi(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<GameUI>().AsSelf().AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<GameOverScreen>().AsSelf().AsImplementedInterfaces();
        }
        private void RegisterPlayer(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<Player>().AsSelf().AsImplementedInterfaces();
            builder.RegisterComponentInHierarchy<HPComponent>().As<IHealthComponent>().As<IGameEventListener>();
        }



        private void RegisterConfigs(IContainerBuilder builder)
        {
            builder.RegisterInstance(weaponConfig.BulletsConfig);
            builder.RegisterInstance(keyboardKonfig.KeyboardInputConfig).As<IKeyboardInputConfig>();

        }
    }
}