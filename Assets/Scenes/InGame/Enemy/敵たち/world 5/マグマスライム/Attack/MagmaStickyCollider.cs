using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaStickyCollider : MonoBehaviour
{
    public float speed = 10f; // �G�̈ړ����x
    public float damageDuration = 2f; // �v���C���[���_���[�W���󂯂鎞��
    public GameObject floorprefab;

    private Transform playerTransform;
    private LifeManager lifeManager;
    private bool isHit = false; // �v���C���[�ɓ����������ǂ����̃t���O
    private bool isGrounded = false; // �n�ʂɓ����������ǂ����̃t���O
    private Vector3 direction; // �v���C���[�̕����x�N�g��

    void Start()
    {
        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManager�R���|�[�l���g���擾����
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // �v���C���[�̕����x�N�g�����v�Z����
        direction = (playerTransform.position - transform.position).normalized;
    }

    void Update()
    {
        // �v���C���[�̕����Ɉ�葬�x�ňړ�����
        transform.position += direction * speed * Time.deltaTime;

        if (isGrounded)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �v���C���[�ɓ��������ꍇ
            lifeManager.GetDamage(1);
            isHit = true;
            Invoke("ResetHit", damageDuration); // ����s�\���Ԍ�ɑ���\�ɖ߂�
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            // �n�ʂɓ��������ꍇ
            isGrounded = true;
            Vector3 contactPoint = collision.ClosestPoint(transform.position);
            // �n�ʂɃI�u�W�F�N�g�𐶐����A���������ʒu�ɒu��
            GameObject obstacle = Instantiate(floorprefab, contactPoint, Quaternion.identity) as GameObject;
            //Destroy(obstacle, 5f); // 5�b��ɃI�u�W�F�N�g���폜����
        }
    }
}