using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public CSVDataManager data;
    public MonsterType type;
    public string Name;

    [SerializeField] private string name;
    [SerializeField] private int level;
    [SerializeField] private int power;
    [SerializeField] private int defend;
    [SerializeField] private string dsc;

    private void Start() => InitDic(Name); // InitTable();

    private void InitDic(string _name)
    {
        name = data.csvDic.GetData(_name, "이름");
        level = int.Parse(data.csvDic.GetData(_name, "레벨"));
        power = int.Parse(data.csvDic.GetData(_name, "공격력"));
        defend = int.Parse(data.csvDic.GetData(_name, "방어력"));
        dsc = data.csvDic.GetData(_name, "특징");
    }

    private void InitTable()
    {
        name = data.csvTable.GetData((int)type, (int)MonsterData.Name);
        level = int.Parse(data.csvTable.GetData((int)type, (int)MonsterData.Level));
        power = int.Parse(data.csvTable.GetData((int)type, (int)MonsterData.Power));
        defend = int.Parse(data.csvTable.GetData((int)type, (int)MonsterData.Defend));
        dsc = data.csvTable.GetData((int)type, (int)MonsterData.Dsc);
    }
}

public enum MonsterType
{
    Slime = 1,
    Skel,
    Dragon
}