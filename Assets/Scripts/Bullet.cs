using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour
{
    [Inject]
    private IBulletConfig bulletConfig;

    public void Update()
    {
        transform.position += transform.forward * bulletConfig.Speed ;
    }

    public class Pool : MemoryPool<Bullet>
    {
        protected override void OnCreated(Bullet item)
        {
            base.OnCreated(item);
            item.name = "myBullet";
        }

        protected override void OnSpawned(Bullet item)
        {
            base.OnSpawned(item);
            
        }

        protected override void OnDespawned(Bullet item)
        {
            base.OnDespawned(item);
      //      item.transform.SetParent(spawnedParent);
        }
    }

}
