using Lessons.Architecture.GameSystem;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField]
    private Bullet bulletPrefab;
    public override void InstallBindings()
    {
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<KeyboardInput>().AsSingle();
        Container.BindInterfacesAndSelfTo<MoveController>().AsSingle().NonLazy();
        Container.BindMemoryPool<Bullet, Bullet.Pool>().WithInitialSize(10).FromComponentInNewPrefab(bulletPrefab);
    }
}