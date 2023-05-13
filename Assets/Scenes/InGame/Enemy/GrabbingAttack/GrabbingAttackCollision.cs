using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingAttackCollision : MonoBehaviour
{
    private LifeManager lifeManager;
    private Transform objTransform;

    private bool MovingPlayer = false;
    private Vector3 PlayerPos;

    private void Start()
    {
        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManager�R���|�[�l���g���擾����
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        objTransform = GameObject.FindWithTag("Player").transform;


        MovingPlayer = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
            //Debug.Log("1damage");

            MovingPlayer = true;
        }
    }

    private void Update()
    {
        if (MovingPlayer)
        {
            objTransform.position = this.transform.position;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        lifeManager.GetDamage(1);
    //        //Debug.Log("1damage");
    //        //Destroy(this.gameObject);

    //        MovingPlayer = true;
    //    }
    //    else
    //    {
    //        //Destroy(this.gameObject);
    //    }
    //}
 }
