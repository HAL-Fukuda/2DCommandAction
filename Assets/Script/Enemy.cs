using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetDamageInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void Hitcheck()
    {
        Debug.Log("�G�ɂ������Ă���");
    }
}
