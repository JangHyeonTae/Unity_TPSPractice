using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager invenInstance;
    public static InventoryManager InvenInstance;

    [SerializeField] GameObject inventoryParent;

    public bool inventoryOpen;
    private void Awake()
    {
        if (InvenInstance == null)
        {
            InvenInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        inventoryOpen = false;
        if(inventoryParent.activeInHierarchy)
            inventoryParent.SetActive(false);
    }
}
