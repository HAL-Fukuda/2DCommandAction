using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    // �ėp�I�Ɏg����ϐ��͂����I



    // Start is called before the first frame update
    void Start()
    {
        // GetDamage
        GetDamageInitialize();
        // EnemyAttack
        EnemyAttackInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        // EnemyAttack
        if (Input.GetKey(KeyCode.E))
        {
            EnemyAttackUpdate();
        }
    }

    // �Փˎ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �^�O��Punch���ǂ���
        if (collision.gameObject.CompareTag("Punch"))
        {
            // �R�}���h�ɍU���������������̏������Ăяo��
            GetDamage();
        }
    }
}
