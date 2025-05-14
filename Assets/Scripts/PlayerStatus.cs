using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    public float WalkSpeed { get; set; }

    [SerializeField] private float runSpeed;
    public float RunSpeed { get; set; }

    [SerializeField] private float rotateSpeed;
    public float RotateSpeed { get; set; }

    private bool isAiming;
    public bool IsAiming { get { return isAiming; } set { isAiming = value; OnAiming?.Invoke(isAiming); } }
    public event Action<bool> OnAiming;

    private bool isMoving;
    public bool IsMoving { get { return isMoving; } set { isMoving = value; OnMoving?.Invoke(isMoving); } }
    public event Action<bool> OnMoving;

    private bool isAttacking;
    public bool IsAttacking { get { return isAttacking; } set { isAttacking = value; OnAttacking?.Invoke(isAttacking); } }
    public event Action<bool> OnAttacking;
}
