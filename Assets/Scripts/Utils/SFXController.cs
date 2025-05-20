using DesignPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : PooledObject
{
    private AudioSource audioSource;

    private float count;

    private void Awake() => Init();

    private void Init()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        count -= Time.deltaTime;
        
        if(count <= 0)
        {
            ReturnPool();
        }
    }

    public void Play(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();

        count = clip.length;
    }
}
