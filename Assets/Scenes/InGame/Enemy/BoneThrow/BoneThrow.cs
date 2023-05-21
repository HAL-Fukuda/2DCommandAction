using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings BoneThrowSettings;
    private float BTspeed = 5.0f; // ���x
    private Rigidbody2D BTrgd;
    private Vector3 BTPosition;

    private GameObject BTobj;

    private bool BTflg = true;

    
    void GetPlayerPositionToBT()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        BTPosition = PlayerObject.transform.position;
        BTPosition.y -= 2.5f;
        BTPosition.z = 0.0f;
        //Debug.Log(BTPosition);
    }

    void GetEnemyPositionBT()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        EnemyPos = EnemyObject.transform.position;
    }

    void BTflgTrue()
    {
        BTflg = true;
    }

    public void BoneThrow()
    {
        if (BTflg)
        {

            GetPlayerPositionToBT();
            GetEnemyPositionBT();

            spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
            BTobj = Instantiate(BoneThrowSettings.prefab, spawnPos, Quaternion.identity);
            BTrgd = BTobj.GetComponent<Rigidbody2D>();


            BTrgd.AddForce(BTPosition * 10.0f);  // �v���C���[�̈ʒu�ɗ͂�������

            //// point1���猩��point2�̑��΍��W���v�Z
            //Vector3 relativePos = EnemyPos - BTPosition;

            //// atan2�֐���p���Ċp�x���v�Z
            //float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;

            // �U���G�t�F�N�g�̌����̏���
            BTobj.transform.DORotate(new Vector3(0, 0, 360), 0.5f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)//�����I�ɕω�����悤��
                .SetLoops(-1);//�i�����[�v    

            BTflg = false;
            Invoke("BTflgTrue", BoneThrowSettings.spawnInterval);
        }

    }


    
}