using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern
{
    public class ObjectPool
    {
        private Queue<PooledObject> que;
        private PooledObject targetPrefab;
        private GameObject poolObject;

        public ObjectPool(Transform parent,PooledObject _targetPrefab, int initSize = 5) => Init(parent,_targetPrefab, initSize);
        private void Init(Transform parent, PooledObject _targetPrefab, int initSize)
        {
            que = new Queue<PooledObject>();
            targetPrefab = _targetPrefab;
            poolObject = new GameObject($"{targetPrefab.name} Pool");
            poolObject.transform.parent = parent;
            for (int i = 0; i < initSize; i++)
            {
                CreatePool();
            }
        }
        public PooledObject DequePool()
        {
            if (que.Count <= 0) CreatePool();

            PooledObject inst = que.Dequeue();
            inst.gameObject.SetActive(true);

            return inst;
        }

        public void EnquePool(PooledObject inst)
        {
            inst.transform.parent = poolObject.transform;
            inst.gameObject.SetActive(false);
            que.Enqueue(inst);
        }

        public void CreatePool()
        {
            PooledObject inst = MonoBehaviour.Instantiate(targetPrefab);
            inst.PooledInit(this);
            EnquePool(inst);
        }
    }
}
