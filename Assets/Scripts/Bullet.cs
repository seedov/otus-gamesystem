
using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Lessons.Architecture.VContainer
{
    public class Bullet : MonoBehaviour
    {
        private float lifeTime;
        private IBulletsConfig bulletsConfig;

        public event Action<Bullet> Destroyed;
        public event Action<Bullet> Hit;

        [Inject]
        private void Construct(IBulletsConfig bulletsConfig)
        {
            this.bulletsConfig = bulletsConfig;
        }

        public void MoveForward(float deltaMove)
        {
            transform.position += transform.forward * deltaMove;
        }

        public void CustomUpdate()
        {

            lifeTime += Time.deltaTime;
            if (lifeTime >= bulletsConfig.Lifetime)
                Destroy(gameObject);
            MoveForward(bulletsConfig.Speed);
        }

        private void OnDestroy()
        {
            Destroyed?.Invoke(this);
        }

        private void OnTriggerEnter(Collider collider)
        {
            var hpComponent = collider.GetComponent<IHealthComponent>();
            if(hpComponent != null)
            {
                hpComponent.ApplyHpChange(bulletsConfig.AffectHp);
                Destroy(gameObject);
            }
        }

    }


}