using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    Rigidbody2D rb;

    private float destroyTimer;  //生成から何秒経ったか
    private bool checkHit = false;  //接地判定用
    
    public float dropSpeed;     //落ちる速度
    public float destroyTime;   //何秒後かに破壊

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        destroyTimer += Time.deltaTime;
        rb.velocity = new Vector3(0,-dropSpeed, 0);

        if (destroyTimer >= destroyTime)  //生成からの経過時間で削除
        {
            Destroy(this.gameObject);
        }
        else if (checkHit)  //あたり判定で削除
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
