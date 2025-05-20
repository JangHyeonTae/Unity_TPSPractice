using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Shoot Settings")]
    [SerializeField][Range(0, 100)] private float attackRange;
    [SerializeField] private float attackDamage;
    [SerializeField] private LayerMask layerMask;

    [Header("Delay Settings")]
    [SerializeField] private float delayTime = 2;
    private float count;
    private bool canShoot { get => count <= 0; }

    [Header("Sound Settings")]
    [SerializeField] private AudioClip audioClip;

    private CinemachineImpulseSource impulse;

    private Camera cam;

    private void Awake() => Init();

    private void Init()
    {
        cam = Camera.main;
        impulse = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        if (canShoot) return;
        count -= Time.deltaTime;
    }


    public bool Shoot()
    {
        if (!canShoot) return false;
        //에임일경우에 가능

        ShootSound();
        ShootImpulseEffect();

        count = delayTime;
        GameObject target = ShootRay();
        if (target == null) return true;
        Debug.Log($"{target.name}");

        return true;
    }

    private GameObject ShootRay()
    {
        Ray ray = new Ray(cam.transform.position,cam.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, attackRange, layerMask))
        {
            return hit.transform.gameObject;
        }
        return null;
    }

    private void ShootSound()
    {
        SFXController sfx = GameManager.Instance.Audio.GetSFX();
        sfx.Play(audioClip);
    }

    private void ShootImpulseEffect()
    {
        impulse.GenerateImpulse();
    }


}
