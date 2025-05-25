using CustomUtility.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonSaveText : SaveData
{
    [field: SerializeField] public int Hp { get; set; }
    [field: SerializeField] public Vector3 playerPos {  get; set; }

    public JsonSaveText() { }

    public JsonSaveText(int _hp, Vector3 _playerPos)
    {
        Hp = _hp;
        playerPos = _playerPos;
    }

}
