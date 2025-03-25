using System.Collections;
using UnityEngine;
using Zenject;

public class BulletSpawner : MonoBehaviour, ITickable
{


    [Inject]
    private Bullet.Pool bulletsFactory;


    private float timeSinceLastShot;

    public void Tick()
    {

        timeSinceLastShot += Time.deltaTime;
        if(timeSinceLastShot >= 1)
        {
            timeSinceLastShot = 0;

            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        var bullet = bulletsFactory.Spawn();
        bullet.OnLifetimeUp += Bullet_OnLifetimeUp;
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

    }

    private void Bullet_OnLifetimeUp(Bullet bullet)
    {
        bullet.OnLifetimeUp -= Bullet_OnLifetimeUp;
        bulletsFactory.Despawn(bullet);
    }


}
