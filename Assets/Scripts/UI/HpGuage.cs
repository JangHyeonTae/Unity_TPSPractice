using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpGuage : MonoBehaviour
{
    [SerializeField] private Image image;
    private Transform camTransform;

    private void Awake() => Init();

    private void Init()
    {
        camTransform = Camera.main.transform;
    }
    void LateUpdate()
    {
        CamRotate(camTransform.forward);
    }

    public void SetHpGuage(float value)
    {
        image.fillAmount = value;
    }

    private void CamRotate(Vector3 target)
    {   
        transform.forward = target;
    }
}
