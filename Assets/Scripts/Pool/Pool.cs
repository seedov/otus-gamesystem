using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Lessons.Architecture.VContainer
{
    public class Pool<T> where T : MonoBehaviour , IPoolable
    {
        private Queue<T> pool = new();
        private T prefab;
        private IObjectResolver resolver;

        public void SetPrefab(T prefab)
        {
            this.prefab = prefab;
        }

        public Pool(IObjectResolver objectResolver)
        {
            resolver = objectResolver;
        }
        public T Spawn()
        {
            if(!pool.TryDequeue(out T t))
            {
                t = resolver.Instantiate(prefab);
            }
            t.Spawn();
            return t;
        }
        public void Despawn(T t)
        {
            t.Despawn();
            pool.Enqueue(t);
        }
    }
}