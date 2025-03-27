using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Lessons.Architecture.VContainer
{
    public class Pool<T> where T : MonoBehaviour , IPoolable
    {
        private Queue<T> pool = new();
        private Func<T> CreateInstance;

        public Pool(Func<T> createInstanceFactory)
        {
            CreateInstance = createInstanceFactory;
        }
        public T Spawn()
        {
            if(!pool.TryDequeue(out T t))
            {
                t = CreateInstance();
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