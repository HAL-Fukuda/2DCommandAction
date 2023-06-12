using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    [SerializeField] private float speed = 1f; // �ړ����x
    [SerializeField] private float distance = 2f; // �ړ�����

    private Vector3 originalPosition; // ���̏����ʒu
    private Vector3 targetPosition; // ���̖ڕW�ʒu
    private int direction = 1; // �ړ������i1:�E�A-1:���j

    private List<Collider2D> colliders = new List<Collider2D>(); // ���̏�ɏ���Ă���I�u�W�F�N�g�̃��X�g

    private void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition + new Vector3(distance * direction, 0f, 0f);
    }

    private void FixedUpdate()
    {
        // �����ړ�����
        transform.position += new Vector3(speed * Time.fixedDeltaTime * direction, 0f, 0f);

        // �ڕW�ʒu�ɓ��B������ړ������𔽓]����
        if ((transform.position - targetPosition).sqrMagnitude < 0.001f)
        {
            direction *= -1;
            targetPosition = originalPosition + new Vector3(distance * direction, 0f, 0f);
        }

        // ���̏�ɏ���Ă���I�u�W�F�N�g���ړ�������
        foreach (Collider2D collider in colliders)
        {
            if (collider != null && collider.gameObject != null)
            {
                collider.gameObject.transform.position += new Vector3(speed * Time.fixedDeltaTime * direction, 0f, 0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���̏�ɃI�u�W�F�N�g��������Ƃ��Ƀ��X�g�ɒǉ�����
        if (other.gameObject.CompareTag("Player"))
        {
            colliders.Add(other);
            Debug.Log("�����");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // ������I�u�W�F�N�g�����ꂽ�Ƃ��Ƀ��X�g����폜����
        if (other.gameObject.CompareTag("Player"))
        {
            colliders.Remove(other);
            Debug.Log("�~�肽");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���̏�ɃI�u�W�F�N�g��������Ƃ��Ƀ��X�g�ɒǉ�����
        if (collision.gameObject.CompareTag("Command"))
        {
            colliders.Add(collision.collider);
            Debug.Log("�R�}���h�����");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // ������I�u�W�F�N�g�����ꂽ�Ƃ��Ƀ��X�g����폜����
        if (collision.gameObject.CompareTag("Command"))
        {
            colliders.Remove(collision.collider);
            Debug.Log("�~�肽");
        }
    }
}
