using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{

    public int MaxHp;
    private int currentHp;
    public int CurrentHp { get { return currentHp; } set { currentHp = value; OnHpChanged?.Invoke(currentHp); } }
    public event Action<int> OnHpChanged;

    private bool isAttacking;
    public bool IsAttacking { get { return isAttacking; } set { isAttacking = value; OnAttacking?.Invoke(isAttacking); } }
    public event Action<bool> OnAttacking;
}
