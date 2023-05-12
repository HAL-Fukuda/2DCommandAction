using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ---------------------------------------------------
// �v���C���[���������Life��-99����B
// �R�}���h��������ƃI�u�W�F�N�g���폜����B
// ----------------------------------------------------
public class DeadZone : MonoBehaviour
{
    private GameObject lifeObject;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lifeObject = GameObject.Find("Life");
            lifeObject.GetComponent<LifeManager>().GetDamage(99);
        }
        
        if(collision.gameObject.tag == "Command")
        {
            // 1�~�炷
            CommandMgr.Instance.DropAll(1);
            Destroy(collision.gameObject);
        }
    }
}
