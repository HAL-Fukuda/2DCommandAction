using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings FoxOnibiSettings;
    private float FOspeed = 7.0f; // ���x
    private Rigidbody2D FOrgd;
    private Vector3 FOPosition;

    private GameObject FOobj;

    private bool FOflg = true;
    private int FOcount = 1;


    void GetPlayerPositionToFO()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        FOPosition = PlayerObject.transform.position;
        FOPosition.y -= 2.5f;
        FOPosition.z = 0.0f;
        //Debug.Log(FOPosition);
    }

    void GetEnemyPositionFO()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform enemyObjectTransform = Enemy.GetComponent<Transform>();

        //GameObject EnemyObject = GameObject.Find("Spider(Clone)");
        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        EnemyPos = EnemyObject.transform.position;
    }

    void FOflgTrue()
    {
        FOflg = true;
        FOcount++;
    }

    public void FoxOnibi()
    {
        if (FOflg)
        {

            GetPlayerPositionToFO();
            GetEnemyPositionFO();

            spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
            FOobj = Instantiate(FoxOnibiSettings.prefab, spawnPos, Quaternion.identity);
            FOrgd = FOobj.GetComponent<Rigidbody2D>();


            FOrgd.AddForce(FOPosition * 10.0f);  // �v���C���[�̈ʒu�ɗ͂�������

            ////�p�x�����p�X�N���v�g
            //// point1���猩��point2�̑��΍��W���v�Z
            //Vector3 relativePos = EnemyPos - FOPosition;
            //// atan2�֐���p���Ċp�x���v�Z
            //float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            //FOobj.transform.DORotate(new Vector3(0, 0, angle), 0, RotateMode.WorldAxisAdd);    // �U���G�t�F�N�g�̌����̏���

            FOflg = false;

            if (FOcount < 5)
            {
                Invoke("FOflgTrue", 0.3f);
                //Debug.Log(FOcount);
            }
            else
            {
                FOcount = 0;
                Invoke("FOflgTrue", FoxOnibiSettings.spawnInterval);
            }
        }

    }
}