using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjected : MonoBehaviour
{
    [field: SerializeField] public Item item { get; set; }

    private GameObject modelPrefab;
    private void Awake()
    {
        modelPrefab = GetComponent<GameObject>();
    }

    private void OnEnable()
    {
        modelPrefab = Instantiate(item.model,transform);
    }

    private void OnDisable()
    {
        Destroy(modelPrefab);
    }
}
