using CustomUtility.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonPlayerSave : MonoBehaviour
{
    [SerializeField] PlayerStatus status;
    [SerializeField] PlayerMovement playerMovement;

    private JsonSaveText jsonSave;
    private JsonSaveText jsonLoad;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SaveJson();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadJson();
        }
    }

    public void SaveJson()
    {
        jsonSave = new(status.CurrentHp, playerMovement.GlobalPos());
        DataSaveController.Save(jsonSave, SaveType.JSON);
    }

    public void LoadJson()
    {
        jsonLoad = new(0, Vector3.zero);
        DataSaveController.Load(ref jsonLoad, SaveType.JSON);
        Debug.Log(jsonLoad.Hp);
        Debug.Log(jsonLoad.playerPos);
        status.CurrentHp = jsonLoad.Hp;
        playerMovement.transform.position = jsonLoad.playerPos;

    }
}
