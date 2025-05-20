using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTester : MonoBehaviour
{
    public AudioManager audioManager;

    public AudioClip sfxClip;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //PoolTest의 부모위치 정하는거 여기서정해줌
            SFXController sfx = audioManager.GetSFX();
            sfx.transform.parent = transform;
            sfx.Play(sfxClip);
        }
    }
}
