using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Lessons.Architecture.VContainer
{
    public class BulletsSpawner : MonoBehaviour,  IPauseTickable
    {
        [SerializeField]
        private Bullet bulletPrefab;

        private IObjectResolver objectResolver;

        private List<Bullet> spawnedBullets = new();

        private float timeSinceLastShot;


        private float shotDelay = 1f;
        private int index;

        [Inject]
        private void Construct(IObjectResolver objectResolver)
        {
            this.objectResolver = objectResolver;
        }

        private void CreateBullet()
        {
            Bullet b = objectResolver.Instantiate<Bullet>(bulletPrefab);

            b.name = $"Bullet_{index}";
            b.transform.position = transform.position;
            b.transform.rotation = transform.rotation;
            b.Destroyed += ProcessBulletDestroyedEvent;
            spawnedBullets.Add(b);

        }

        private void ProcessBulletDestroyedEvent(Bullet bullet)
        {
            bullet.Destroyed -= ProcessBulletDestroyedEvent;
            spawnedBullets.Remove(bullet);
        }


        void IPauseTickable.Tick()
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