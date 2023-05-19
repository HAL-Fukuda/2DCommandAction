using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings RockThrowingSettings;
    private float RTspeed = 9.0f; // ���x
    private Rigidbody2D RTrgd;
    private Vector3 RTPosition;

    private GameObject RTobj;

    private bool RTflg = true;
    private int RTcount = 1;


    void GetPlayerPositionToRT()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        RTPosition = PlayerObject.transform.position;
        RTPosition.y -= 2.5f;
        RTPosition.z = 0.0f;
        //Debug.Log(FOPosition);
    }

    void GetEnemyPositionRT()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform enemyObjectTransform = Enemy.GetComponent<Transform>();

        //GameObject EnemyObject = GameObject.Find("Spider(Clone)");
        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        EnemyPos = EnemyObject.transform.position;
    }

    void RTflgTrue()
    {
        RTflg = true;
        RTcount++;
    }

    public void RockThrowing()
    {
        if (RTflg)
        {

            GetPlayerPositionToRT();
            GetEnemyPositionRT();

            spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
            RTobj = Instantiate(RockThrowingSettings.prefab, spawnPos, Quaternion.identity);
            RTrgd = RTobj.GetComponent<Rigidbody2D>();


            RTrgd.AddForce(RTPosition * 10.0f);  // �v���C���[�̈ʒu�ɗ͂�������

            ////�p�x�����p�X�N���v�g
            //// point1���猩��point2�̑��΍��W���v�Z
            //Vector3 relativePos = EnemyPos - FOPosition;
            //// atan2�֐���p���Ċp�x���v�Z
            //float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            //FOobj.transform.DORotate(new Vector3(0, 0, angle), 0, RotateMode.WorldAxisAdd);    // �U���G�t�F�N�g�̌����̏���

            RTflg = false;

            if (RTcount < 3)
            {
                Invoke("RTflgTrue", 0.7f);
                Debug.Log(RTcount);
            }
            else
            {
                RTcount = 0;
                Invoke("RTflgTrue", RockThrowingSettings.spawnInterval);
            }
        }

    }
}
