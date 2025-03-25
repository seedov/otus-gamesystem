using System;
using System.Collections;
using UnityEngine;
using Zenject;
using static UnityEditor.Progress;

public class Bullet : MonoBehaviour
{
    [Inject]
    private IBulletConfig bulletConfig;
    public event Action<Bullet> OnLifetimeUp;

    public void Update()
    {
            transform.position += transform.forward * bulletConfig.Speed ;
    }

    public void Enable()
    {
        gameObject.SetActive(true);
        StartCoroutine(BulletLifetimeCoroutine());
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator BulletLifetimeCoroutine()
    {
        yield return new WaitForSeconds(bulletConfig.Lifetime);
        OnLifetimeUp?.Invoke(this);
    }

    public class Pool : MemoryPool<Bullet>
    {
        protected override void OnCreated(Bullet item)
        {
            base.OnCreated(item);
            item.name = "myBullet";
            item.Disable();
            
        }

        protected override void OnSpawned(Bullet item)
        {
            base.OnSpawned(item);
            item.gameObject.SetActive(true);
            item.Enable();
        }

        protected override void OnDespawned(Bullet item)
        {
            base.OnDespawned(item);
            item.Disable();
      //      item.transform.SetParent(spawnedParent);
        }
    }

}
