using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings SpiderNeedleSettings;
    private float SNspeed = 5.0f; // ���x
    private Rigidbody2D SNrgd;
    private Vector3 SNPosition;

    private GameObject SNobj;

    private bool SNflg = true;


    void GetPlayerPositionToSN()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        SNPosition = PlayerObject.transform.position;
        SNPosition.y -= 2.5f;
        SNPosition.z = 0.0f;
        //Debug.Log(SNPosition);
    }

    void GetEnemyPositionSN()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform enemyObjectTransform = Enemy.GetComponent<Transform>();

        //GameObject EnemyObject = GameObject.Find("Spider(Clone)");
        GameObject EnemyObject = GameObject.Find("Enemy");

        EnemyPos = EnemyObject.transform.position;
    }

    void SNflgTrue()
    {
        SNflg = true;
    }

    public void SpiderNeedle()
    {
        if (SNflg)
        {

            GetPlayerPositionToSN();
            GetEnemyPositionSN();

            spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
            SNobj = Instantiate(SpiderNeedleSettings.prefab, spawnPos, Quaternion.identity);
            SNrgd = SNobj.GetComponent<Rigidbody2D>();


            SNrgd.AddForce(SNPosition * 10.0f);  // �v���C���[�̈ʒu�ɗ͂�������

            // point1���猩��point2�̑��΍��W���v�Z
            Vector3 relativePos = EnemyPos - SNPosition;

            // atan2�֐���p���Ċp�x���v�Z
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;


            SNobj.transform.DORotate(new Vector3(0, 0, angle), 0, RotateMode.WorldAxisAdd);    // �U���G�t�F�N�g�̌����̏���

            SNflg = false;
            Invoke("SNflgTrue", SpiderNeedleSettings.spawnInterval);
        }

    }


    // Update is called once per frame


    // Update�������ăG���[�ł�
    // Update�������ꏊ��ς��邩������Ȃ�

    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        SideVanishAttack();
    //    }

    //    if (rgd != null)
    //    {
    //        // ���x�̏���ݒ�
    //        if (rgd.velocity.magnitude > SVAspeed)
    //        {
    //            rgd.velocity = rgd.velocity.normalized * SVAspeed;  // �ő呬�x��݂���
    //        }
    //    }
    //}
}
