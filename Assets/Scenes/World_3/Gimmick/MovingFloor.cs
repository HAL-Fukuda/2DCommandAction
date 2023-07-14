using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    [SerializeField] private float speed = 1f; // �ړ����x
    [SerializeField] private float distance = 2f; // �ړ�����

    private Vector3 originalPosition; // ���̏����ʒu
    private Vector3 targetPosition; // ���̖ڕW�ʒu
    public int direction = 1; // �ړ������i1:�E�A-1:���j
    public Vector3 moveVal;

    private void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition + new Vector3(distance * direction, 0f, 0f);
    }

    private void FixedUpdate()
    {
        // �����ړ�����
        moveVal= new Vector3(speed * Time.fixedDeltaTime * direction, 0f, 0f);
        transform.position += moveVal;

        // �ڕW�ʒu�ɓ��B������ړ������𔽓]����
        if ((transform.position - targetPosition).sqrMagnitude < 0.001f)
        {
            direction *= -1;
            targetPosition = originalPosition + new Vector3(distance * direction, 0f, 0f);
        }

        //// ���̏�ɏ���Ă���I�u�W�F�N�g���ړ�������
        //foreach (Collider2D collider in colliders)
        //{
        //    if (collider != null && collider.gameObject != null)
        //    {
        //        collider.gameObject.transform.position += new Vector3(speed * Time.fixedDeltaTime * direction, 0f, 0f);
        //    }
        //}
    }
}
