using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goblin : Monster, IDamagable
{
    private bool isActive = true;

    [Header("Move Settings")]
    [SerializeField] Transform target;
    [SerializeField] private float range;
    [SerializeField] private LayerMask targetLayer;
    private float targetDistance;

    [Header("Attack Settings")]
    [SerializeField] private float attackRange;
    [SerializeField] private int attackDamage;
    public event Action<int> OnAttack;

    private NavMeshAgent agent;

    private float attackCount;
    private float attackDelay = 2f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        OnAttack += Attack;
    }

    private void OnDisable()
    {
        OnAttack -= Attack;
    }

    private void Update()
    {
        if (attackCount <= 0)
        {
            IsAttacking = true;
        }
        else
        {
            attackCount -= Time.deltaTime;
        }
        SetMoveTarget();
    }

    private void SetMoveTarget()
    {
        if (!isActive) return;
        Move();
    }

    private void Move()
    {
        if (target == null) return;
        targetDistance = Vector3.Distance(transform.position, target.position);
        if (TargetIn())
        {
            if (targetDistance < attackRange)
            {
                if (IsAttacking)
                {
                    attackCount = attackDelay;
                    OnAttack?.Invoke(attackDamage);
                }
            }
            else
            {
                agent.isStopped = false;
                agent.SetDestination(target.position);
            }
             
        }
    }


    private void Attack(int damage)
    {
        if (IsAttacking)
        {
            Debug.Log($"Damage : {damage}");
            agent.isStopped = true;
            IDamagable setTarget = SetTarget();
            setTarget.TakeDamage(attackDamage);
            IsAttacking = false;
        }
    }



    private IDamagable SetTarget()
    {
        if (target != null)
        {
            IsAttacking = true;
            return target.GetComponent<IDamagable>();
        }
        return null;
    }

    private bool TargetIn()
    {
        if (Physics.OverlapSphere(transform.position, range, targetLayer).Length > 0)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void TakeDamage(int amount)
    {
        int hp = CurrentHp - amount;
        CurrentHp = Mathf.Clamp(hp, 0, CurrentHp);
    }
}
