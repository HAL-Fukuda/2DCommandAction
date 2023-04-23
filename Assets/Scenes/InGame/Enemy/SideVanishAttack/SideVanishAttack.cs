using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings SideVanishAttackSettings;
    public GameObject Enemy;
    private Vector3 EnemyPos;
    public float SVAspeed; // ���x
    private Rigidbody2D rgd;
    private Vector3 SVAPosition;

    private GameObject SVAobj;

    private bool SVAflg = true;


    void GetPlayerPositionToSVA()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        Transform myObjectTransform = player1.GetComponent<Transform>();

        SVAPosition = myObjectTransform.position;
        SVAPosition.y -= 3.5f;
        SVAPosition.z = 0.0f;
        //Debug.Log(SVAPosition);
    }

    void GetEnemyPosition()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        Transform enemyObjectTransform = Enemy.GetComponent<Transform>();

        EnemyPos = enemyObjectTransform.position;
    }

    void SVAflgTrue()
    {
        SVAflg = true;
    }

    public void SideVanishAttack()
    {
        if (SVAflg)
        {

            GetPlayerPositionToSVA();
            GetEnemyPosition();

            spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
            SVAobj = Instantiate(SideVanishAttackSettings.prefab, spawnPos, Quaternion.identity);
            rgd = SVAobj.GetComponent<Rigidbody2D>();


            rgd.AddForce(SVAPosition * 10.0f);  // �v���C���[�̈ʒu�ɗ͂�������

            // point1���猩��point2�̑��΍��W���v�Z
            Vector3 relativePos = EnemyPos - SVAPosition;

            // atan2�֐���p���Ċp�x���v�Z
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;


            SVAobj.transform.DORotate(new Vector3(0, 0, angle), 0, RotateMode.WorldAxisAdd);    // �U���G�t�F�N�g�̌����̏���

            SVAflg = false;
            Invoke("SVAflgTrue", SideVanishAttackSettings.spawnInterval);
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
