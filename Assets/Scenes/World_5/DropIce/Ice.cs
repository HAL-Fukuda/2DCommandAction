using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    Rigidbody2D rb;

    private float destroyTimer;  //�������牽�b�o������
    private bool checkHit = false;  //�ڒn����p
    
    public float dropSpeed;     //�����鑬�x
    public float destroyTime;   //���b�ォ�ɔj��

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        destroyTimer += Time.deltaTime;
        rb.velocity = new Vector3(0,-dropSpeed, 0);

        if (destroyTimer >= destroyTime)  //��������̌o�ߎ��Ԃō폜
        {
            Destroy(this.gameObject);
        }
        else if (checkHit)  //�����蔻��ō폜
        {
            Destroy(this.gameObject);
            checkHit = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            checkHit = true;
        }
        else if (other.gameObject.CompareTag("Command"))
        {
            checkHit = true;
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            checkHit = true;
        }
    }
}
