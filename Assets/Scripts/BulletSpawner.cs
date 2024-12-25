using System.Collections;
using UnityEngine;
using Zenject;

public class BulletSpawner : MonoBehaviour
{


    [Inject]
    private Bullet.Pool bulletsFactory;

    [Inject]
    private IBulletConfig bulletConfig;

    private float timeSinceLastShot;

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if(timeSinceLastShot >= 1)
        {
            timeSinceLastShot = 0;

            StartCoroutine(SpawnBullet());
        }
    }

    private IEnumerator SpawnBullet()
    {
        var bullet = bulletsFactory.Spawn();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        yield return new WaitForSeconds(bulletConfig.Lifetime);
        bulletsFactory.Despawn(bullet);
    }
}
