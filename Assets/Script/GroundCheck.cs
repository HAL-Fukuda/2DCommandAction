using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Platform";  //�������Ă��邩�𔻒肷�鑊��̃^�O

    private bool isGround = false;  //�ڒn����
    private bool isGroundEnter,     //�ڒn����(�ڒn�������ǂ����j
                 isGroundStay,      //�ڒn����(�ڒn�������Ă��邩�ǂ����j
                 isGroundExit;      //�ڒn����(�ڒn���Ȃ��Ȃ������ǂ����j

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Player����Ăׂ�t���O���쐬
    //�������薈�ɌĂ�
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

    //�ڒn����(�ڒn�������ǂ����j
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
            //Debug.Log("�ڒn���Ă���");
            //Debug.Log(collision.tag);
        }
    }

    //�ڒn����(�ڒn�������Ă��邩�ǂ����j
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
            //Debug.Log("�ڒn�������Ă���");
            //Debug.Log(collision.tag);
        }
    }

    //�ڒn����(�ڒn���Ȃ��Ȃ������ǂ����j
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
            //Debug.Log("�ڒn���Ȃ��Ȃ���");
        }
    }
}
