using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isControllActivate { get; set; } = true;

    private PlayerStatus status;
    private PlayerMovement movement;

    [SerializeField] private GameObject aimCamera;
    [SerializeField] GameObject mainCamera;

    [SerializeField] private KeyCode aimKey = KeyCode.Mouse1;

    private void Awake()
    {
        status = GetComponent<PlayerStatus>();
        movement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        SubscribeEvents();   
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    private void Update()
    {
        HandlePlayerController();
    }


    private void HandlePlayerController()
    {
        if (!isControllActivate) return;
        HandleMovement();
        HandleAming();
    }

    private void HandleMovement()
    {
        Vector3 camRotateDir = movement.SetRotate();

        float moveSpeed;
        if (status.IsAiming)
            moveSpeed = status.WalkSpeed;
        else
            moveSpeed = status.RunSpeed;

        Vector3 moveDir = movement.SetMove(moveSpeed);
        if (moveDir.magnitude > 0)
            status.IsMoving = true;

        Vector3 avatarDir;
        if (status.IsAiming)
            avatarDir = camRotateDir;
        else
            avatarDir = moveDir;

        movement.SetAvatarRotation(avatarDir);
    }

    private void HandleAming()
    {
        status.IsAiming = Input.GetKey(aimKey);
    }

    private void SubscribeEvents()
    {
        status.OnAiming += SetActiveCamera;
    }

    private void UnSubscribeEvents()
    {
        status.OnAiming -= SetActiveCamera;
    }

    private void SetActiveCamera(bool value)
    {
        aimCamera.SetActive(value);
        mainCamera.SetActive(!value);
    }
}
