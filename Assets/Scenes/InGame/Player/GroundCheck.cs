using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Platform";  //当たっているかを判定する相手のタグ

    private bool isGround = false;  //接地判定
    private bool isGroundEnter,     //接地判定(接地したかどうか）
                 isGroundStay,      //接地判定(接地し続けているかどうか）
                 isGroundExit;      //接地判定(接地しなくなったかどうか）

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Playerから呼べるフラグを作成
    //物理判定毎に呼ぶ
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }
        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    //接地判定(接地したかどうか）
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
            //Debug.Log("接地している");
            //Debug.Log(collision.tag);
        }
    }

    //接地判定(接地し続けているかどうか）
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
            //Debug.Log("接地し続けている");
            //Debug.Log(collision.tag);
        }
    }

    //接地判定(接地しなくなったかどうか）
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
            //Debug.Log("接地しなくなった");
        }
    }
}
