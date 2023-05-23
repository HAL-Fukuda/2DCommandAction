using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CACollision : MonoBehaviour
{
    private LifeManager lifeManager;

    private void Start()
    {
        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManager�R���|�[�l���g���擾����
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(3);
            //Destroy(gameObject);
            //Debug.Log("������");
        }
    }

}
