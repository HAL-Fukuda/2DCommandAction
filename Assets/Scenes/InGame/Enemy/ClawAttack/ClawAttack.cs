using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    

    // �v���C���[�I�u�W�F�N�g���Q�Ƃ���
    //public GameObject player1;  // �v���C���[�̈ʒu�擾�p

    public AttackSettings ClawComingAttackSettings;
    public AttackSettings ClawAttackSettings;

    // �I�u�W�F�N�g�̈ʒu���擾����
    private Vector3 CAPosition;

    private bool CAflg = true;

    void RightCA()
    {

        CAPosition = new Vector3(6, 0, 0);

        Debug.Log("�|�W�V�����擾");
    }

    void LeftCA()
    {

        CAPosition = new Vector3(-6, 0, 0);

        Debug.Log("�|�W�V�����擾");
    }

    void premonitionCA()
    {

        // �v���C���[�̈ʒu�ɗ\������
        spawnPos = new Vector3(CAPosition.x, 0f, 0f);
        GameObject obj = Instantiate(ClawComingAttackSettings.prefab, spawnPos, Quaternion.identity);
        obj.transform.DOMoveY(
                0, //�ړ���
                2.5f // ���o����
            ).OnComplete(() =>
            {
                RealClaw();
                Destroy(obj);
                
            });
    }

    void RealClaw()
    {
        // �v���C���[�̈ʒu�Ƀr�[������
        //Vector3 spawnPos = new Vector3(objectPosition.x, 0f, 0f);
        GameObject obj1 = Instantiate(ClawAttackSettings.prefab, spawnPos, Quaternion.identity);
        obj1.transform.DOMoveY(
                0, //�ړ���
                1.5f // ���o����
            ).OnComplete(() =>
            {
                Destroy(obj1);
            });
    }

    void CAflgTrue()
    {
        CAflg = true;
        Debug.Log("�t���O���g�D���[");
    }

    public void ClawAttackRight()
    {
        if (CAflg)
        {
            RightCA();
            premonitionCA();

            CAflg = false;
            Invoke("CAflgTrue", ClawComingAttackSettings.spawnInterval + ClawAttackSettings.spawnInterval);
        }
        //Debug.Log(objectPosition);
    }

    public void ClawAttackLeft()
    {
        if (CAflg)
        {
            LeftCA();
            premonitionCA();

            CAflg = false;
            Invoke("CAflgTrue", ClawComingAttackSettings.spawnInterval + ClawComingAttackSettings.spawnInterval);
        }
        //Debug.Log(objectPosition);
    }


    // Start is called before the first frame update


    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        SatelliteBeam();
    //    }
    //}
}