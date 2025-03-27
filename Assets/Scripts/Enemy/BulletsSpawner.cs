using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Lessons.Architecture.VContainer
{
    public class BulletsSpawner : MonoBehaviour, ITickable
    {
        [SerializeField]
        private Bullet bulletPrefab;

        private Pool<Bullet> bulletsPool;

        private List<Bullet> spawnedBullets = new();

        private float timeSinceLastShot;


        private float shotDelay = 1f;
        private int index;

        [Inject]
        private void Construct(Pool<Bullet> pool)
        {
            bulletsPool = pool;
        }

        private void CreateBullet()
        {
            var b = bulletsPool.Spawn();
            b.transform.position = transform.position;
            b.transform.rotation = transform.rotation;
            b.Hit += ProcessBulletHitEvent;
            b.LifetimeIsOver += BulletLifetimeIsOver;
            spawnedBullets.Add(b);

        }

        private void DespawnBullet(Bullet bullet)
        {
            bullet.LifetimeIsOver -= BulletLifetimeIsOver;
            bullet.Hit -= ProcessBulletHitEvent;
            spawnedBullets.Remove(bullet);
            bulletsPool.Despawn(bullet);
        }

        private void BulletLifetimeIsOver(Bullet bullet)
        {
            DespawnBullet(bullet);
        }

        private void ProcessBulletHitEvent(Bullet bullet)
        {
            DespawnBullet(bullet);
        }


        public void Tick()
        {
            if (timeSinceLastShot >= shotDelay)
            {
                timeSinceLastShot = 0;
                CreateBullet();

                ++index;
            }
            timeSinceLastShot += Time.deltaTime;

            for(var i = 0; i<spawnedBullets.Count; ++i)
            {
                var bullet = spawnedBullets[i];
                bullet.CustomUpdate();
            }
        }
    }
}