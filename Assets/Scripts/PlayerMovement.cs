using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigid;
    private PlayerStatus status;

    [Header("Cam Setting")]
    [SerializeField] private Transform aim;
    [SerializeField] private Transform avatar;
    [SerializeField][Range(-90, 0)]
    private float minPitch;
    [SerializeField] [Range(0, 90)]
    private float maxPitch;

    [Header("Rotate Setting")]
    [SerializeField] private float mouseSensitivity = 1;
    //���� ȸ������ �ҷ����� ����
    Vector2 currentRotation;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        status = GetComponent<PlayerStatus>();
    }

    public Vector3 SetAimRotate()
    {
        Vector2 mouse;
        mouse.x = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouse.y = -Input.GetAxis("Mouse Y") * mouseSensitivity;

        currentRotation.x += mouse.x;

        currentRotation.y = Mathf.Clamp(currentRotation.y + mouse.y, minPitch, maxPitch);

        //ĳ���� ������Ʈ�� �����ϰ��
        transform.rotation = Quaternion.Euler(0, currentRotation.x, 0);

        //������ ȸ��
        Vector3 currentEuler = aim.localEulerAngles;
        aim.localEulerAngles = new Vector3(currentRotation.y, currentEuler.y, currentEuler.z);

        //ȸ�� ���� ���� ��ȯ
        Vector3 rotateDirVector = transform.forward;
        rotateDirVector.y = 0;

        return rotateDirVector.normalized;
    }

    public void SetAvatarRotation(Vector3 direction)
    {
        if (direction == Vector3.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        avatar.rotation = Quaternion.Lerp(avatar.rotation, targetRotation, status.RotateSpeed * Time.deltaTime);
    }

    public Vector3 SetMove(float speed)
    {
        Vector3 moveDir = GetMoveDirection();

        Vector3 vel = rigid.velocity;
        vel.x = moveDir.x * speed;
        vel.z = moveDir.z * speed;

        rigid.velocity = vel;

        return moveDir;
    }

    public Vector3 GetMoveDirection()
    {
        Vector3 input = GetInputDirection();

        Vector3 dir = (transform.right * input.x) + (transform.forward * input.z);

        return dir.normalized; // ����ȭ - ũ�⸦ �����ϰ� ���⸸ ����
    }

    public Vector3 GetInputDirection()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
    
        return new Vector3(x, 0, z);
    }
}
