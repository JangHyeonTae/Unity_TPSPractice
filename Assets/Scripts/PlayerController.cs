using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool isControllActivate { get; set; } = true;

    private PlayerStatus status;
    private PlayerMovement movement;
    [SerializeField] private Gun gun;

    [SerializeField] private CinemachineVirtualCamera aimCamera;

    [SerializeField] private KeyCode aimKey = KeyCode.Mouse1;
    [SerializeField] private KeyCode shootKey = KeyCode.Mouse0;

    [Header("Game Setting")]
    [SerializeField] private HpGuage hpBar;

    private Animator animator;
    [SerializeField] private Animator aimAnimator;
    private Image aimImage; 
    private void Awake()
    {
        status = GetComponent<PlayerStatus>();
        movement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        aimImage = aimAnimator.GetComponent<Image>();

        status.CurrentHp = status.MaxHp;
        hpBar.SetHpGuage(1);
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
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Heal(1);
        }
    }


    private void HandlePlayerController()
    {
        if (!isControllActivate) return;

        HandleMovement();
        HandleAming();
        HandleShoot();
    }

    private void HandleShoot()
    {
        if (status.IsAiming && Input.GetKey(shootKey))
        {
            status.IsAttacking = gun.Shoot();
        }
        else
        {
            status.IsAttacking = false;
        }
    }

    private void HandleMovement()
    {
        Vector3 camRotateDir = movement.SetAimRotate();

        float moveSpeed;
        if (status.IsAiming)
            moveSpeed = status.WalkSpeed;
        else
            moveSpeed = status.RunSpeed;

        Vector3 moveDir = movement.SetMove(moveSpeed);
        status.IsMoving = (moveDir != Vector3.zero);
        

        Vector3 avatarDir;
        if (status.IsAiming)
            avatarDir = camRotateDir;
        else
            avatarDir = moveDir;

        movement.SetAvatarRotation(avatarDir);

        if (status.IsAiming)
        {
            Vector3 input = movement.GetInputDirection();
            animator.SetFloat("X", input.x);
            animator.SetFloat("Y", input.z);
        }
    }

    
    private void HandleAming()
    {
        status.IsAiming = Input.GetKey(aimKey);
    }

    public void TakeDamage(int amount)
    {
        status.CurrentHp = Mathf.Max(0, status.CurrentHp - amount);
        //IsTakeDamage == true;
        if (status.CurrentHp <= 0)
        {
            //Die();
        }
    }

    public void Heal(int amount)
    {
        status.CurrentHp = Mathf.Min(status.MaxHp, status.CurrentHp + amount);
        //IsTakeDamage == true;
    }

    private void SubscribeEvents()
    {
        status.OnAiming += SetCam;
        status.OnAiming += SetAimAnimation;
        status.OnMoving += SetMoveAnimation;
        status.OnAttacking += SetAttackAnimation;
        status.OnHpChanged += SetHpUIGuage;
    }

    private void UnSubscribeEvents()
    {
        status.OnAiming -= SetCam;
        status.OnAiming -= SetAimAnimation;
        status.OnMoving -= SetMoveAnimation;
        status.OnAttacking -= SetAttackAnimation;
        status.OnHpChanged -= SetHpUIGuage;
    }

    private void SetCam(bool value)
    {
        aimCamera.gameObject.SetActive(value);
    }

    private void SetAimAnimation(bool value)
    {
        if (!aimImage.enabled) aimImage.enabled = true;
        animator.SetBool("IsAim", value);
        aimAnimator.SetBool("IsAim", value);
    }
        
    private void SetMoveAnimation(bool value) => animator.SetBool("IsMoving", value);
    private void SetAttackAnimation(bool value) => animator.SetBool("IsAttack", value);

    //SetTakeDamageAnimation => animator.SetTrigger("TakeDamage");
    private void SetHpUIGuage(int value)
    {
        float hp = value / (float)status.MaxHp;
        hpBar.SetHpGuage(hp);
    }
}
