using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    public float WalkSpeed { get { return walkSpeed; } set { walkSpeed = value; } }

    [SerializeField] private float runSpeed;
    public float RunSpeed { get { return runSpeed; } set { runSpeed = value; } }

    [SerializeField] private float rotateSpeed;
    public float RotateSpeed { get { return rotateSpeed; } set { rotateSpeed = value; } }

    public int MaxHp;


    [field: SerializeField] private int currentHp;
    public int CurrentHp { get { return currentHp; } set { currentHp = value; OnHpChanged?.Invoke(currentHp); } }
    public event Action<int> OnHpChanged;

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
