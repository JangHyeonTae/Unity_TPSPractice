using CustomUtility.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVDataManager : MonoBehaviour
{
    [field: SerializeField] public CsvTable csvTable { get; private set; }
    [field : SerializeField] public CsvDictionary csvDic {  get; private set; }

    private void Awake()
    {
        CsvReader.Read(csvTable);
        CsvReader.Read(csvDic);
    }
}

public enum MonsterData
{
    Name = 1,
    Level,
    Power,
    Defend,
    Dsc
}
