using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string name;
    public string dsc;
    public Sprite icon;
    public GameObject model;

    public virtual void Use(PlayerController controller) { }
}
