using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern
{
    public abstract class PooledObject : MonoBehaviour
    {
        private ObjectPool ObjectPool { get; set; }

        public void PooledInit(ObjectPool objectPool)
        {
            ObjectPool = objectPool;
        }

        public void ReturnPool()
        {
            ObjectPool.EnquePool(this);
        }
    }
}

