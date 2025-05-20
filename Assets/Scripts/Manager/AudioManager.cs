using DesignPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource bgmSource;

    [SerializeField] private List<AudioClip> bgmList = new();

    [SerializeField] private SFXController sfxPrefab; // 이걸 사용함

    private ObjectPool sfxPool;
    private void Awake()
    {
        bgmSource = GetComponent<AudioSource>();
        sfxPool = new ObjectPool(transform,sfxPrefab, 10);
    }

    public void BgmPlay(int index)
    {
        if (0 <= index && index < bgmList.Count)
        {
            bgmSource.Stop();
            bgmSource.clip = bgmList[index];
            bgmSource.Play();
        }
        
    }

    public SFXController GetSFX()
    {
        PooledObject inst = sfxPool.DequePool();
        return inst as SFXController;
    }
}
