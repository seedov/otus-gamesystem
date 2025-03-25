using System;
using Lessons.Architecture.GameSystem;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private Turel[] turels;
    public override void InstallBindings()
    {
        foreach (var turel in turels)
            BindTurel(turel);

        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<KeyboardInput>().AsSingle();
        Container.BindInterfacesTo<MoveController>().AsSingle();
        Container.BindMemoryPool<Bullet, Bullet.Pool>().WithInitialSize(10).FromComponentInNewPrefab(bulletPrefab);
    }

    private void BindTurel(Turel turel)
    {
        Container.BindInterfacesTo<Turel>().FromInstance(turel);
        var spawner = turel.GetComponentInChildren<BulletSpawner>();
        Container.BindInterfacesTo<BulletSpawner>().FromInstance(spawner);
    }
}