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
            lifeObject.GetComponent<LifeManager>().Kill();
        }
        
        if(collision.gameObject.tag == "Command")
        {
            Destroy(collision.gameObject);
        }
    }
}
