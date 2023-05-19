using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings FlameSplashSettings;
    private float FSspeed = 7.0f; // ���x
    private Rigidbody2D FSrgd;
    private Vector3 FSPosition;

    private GameObject FSobj;

    private bool FSflg = true;
    private int FScount = 1;


    void GetPlayerPositionToFS()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        FSPosition = PlayerObject.transform.position;
        FSPosition.y -= 2.5f;
        FSPosition.z = 0.0f;
        //Debug.Log(FOPosition);
    }

    void GetEnemyPositionFS()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform enemyObjectTransform = Enemy.GetComponent<Transform>();

        //GameObject EnemyObject = GameObject.Find("Spider(Clone)");
        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        EnemyPos = EnemyObject.transform.position;
    }

    void FSflgTrue()
    {
        FSflg = true;
        FScount++;
    }

    public void FlameSplash()
    {
        if (FSflg)
        {

            GetPlayerPositionToFS();
            GetEnemyPositionFS();

            spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
            FSobj = Instantiate(FlameSplashSettings.prefab, spawnPos, Quaternion.identity);
            FSrgd = FSobj.GetComponent<Rigidbody2D>();


            FSrgd.AddForce(FSPosition * 10.0f);  // �v���C���[�̈ʒu�ɗ͂�������

            ////�p�x�����p�X�N���v�g
            //// point1���猩��point2�̑��΍��W���v�Z
            //Vector3 relativePos = EnemyPos - FOPosition;
            //// atan2�֐���p���Ċp�x���v�Z
            //float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            //FOobj.transform.DORotate(new Vector3(0, 0, angle), 0, RotateMode.WorldAxisAdd);    // �U���G�t�F�N�g�̌����̏���

            FSflg = false;

            if (FScount < 10)
            {
                Invoke("FSflgTrue", 0.3f);
                Debug.Log(FScount);
            }
            else
            {
                FScount = 0;
                Invoke("FSflgTrue", FlameSplashSettings.spawnInterval);
            }
        }

    }
}
