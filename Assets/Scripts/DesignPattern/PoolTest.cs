using DesignPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour
{
    [SerializeField] private PooledObjectTest prefab;

    private ObjectPool pool;
    private PooledObject temp;

    private void Awake()
    {
        pool = new ObjectPool(transform, prefab,10);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            temp = pool.DequePool();
            temp.transform.parent = transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            temp.ReturnPool();
        }
    }
}
