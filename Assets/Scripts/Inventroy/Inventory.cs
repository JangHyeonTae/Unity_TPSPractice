using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new();
    private Image itemIcon;
    private GameObject itemObject;

    public void GetItem(Item item)
    {
        items.Add(item);
    }


    public void UseItem(Item item)
    {
        items.Remove(item);
    }
}
