
using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Lessons.Architecture.VContainer
{
    public class Bullet : MonoBehaviour, IPoolable
    {
        private float lifeTime;
        private IBulletsConfig bulletsConfig;

        public event Action<Bullet> Hit;
        public event Action<Bullet> LifetimeIsOver;

        [Inject]
        private void Construct(IBulletsConfig bulletsConfig)
        {
            this.bulletsConfig = bulletsConfig;
        }

        public void MoveForward(float deltaMove)
        {
            transform.position += transform.forward * deltaMove;
        }

        public void Clear()
        {
            lifeTime = 0;
        }

        public void CustomUpdate()
        {

            lifeTime += Time.deltaTime;
            if (lifeTime >= bulletsConfig.Lifetime)
                LifetimeIsOver?.Invoke(this);
            else
                MoveForward(bulletsConfig.Speed);
        }

        private void OnTriggerEnter(Collider collider)
        {
            var hpComponent = collider.GetComponent<IHealthComponent>();
            if(hpComponent != null)
            {
                hpComponent.ApplyHpChange(bulletsConfig.AffectHp);
                Hit?.Invoke(this);
            }
        }

        public void Spawn()
        {
            gameObject.SetActive(true);
            Clear();
        }

        public void Despawn()
        {
            gameObject.SetActive(false);
            Clear();
        }
    }


}