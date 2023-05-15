using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings GrabbingAttackSettings;

    public float GAspeed; // ���x
    private Rigidbody2D GArgd;
    private Vector3 GAPosition;

    private GameObject GAobj;

    private bool GAflg = true;


    void GetPlayerPositionToGA()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.FindWithTag("Player");

        GAPosition = PlayerObject.transform.position;
        //GAPosition.y -= 3.5f;
        GAPosition.z = 0.0f;
        //Debug.Log(GAPosition);
    }

    void GetEnemyPositionGA()
    {
        // �Q�[���I�u�W�F�N�g��Transform�R���|�[�l���g���擾����
        //Transform enemyObjectTransform = Enemy.GetComponent<Transform>();

        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        EnemyPos = EnemyObject.transform.position;
    }

    void GAflgTrue()
    {
        GAflg = true;
    }

    void GAobjDestroy()
    {
        Destroy(GAobj);
    }



    public void GrabbingAttack()
    {
        if (GAflg)
        {

            GetPlayerPositionToGA();
            GetEnemyPositionGA();

            spawnPos = new Vector3(EnemyPos.x, EnemyPos.y, 0.0f);
            GAobj = Instantiate(GrabbingAttackSettings.prefab, spawnPos, Quaternion.identity);
            GArgd = GAobj.GetComponent<Rigidbody2D>();

            GAobj.transform.DOMove(GAPosition, 1.0f)
                .SetLoops(2, LoopType.Yoyo)
                .OnComplete(GAobjDestroy);

            //// point1���猩��point2�̑��΍��W���v�Z
            //Vector3 relativePos = EnemyPos - GAPosition;
            //// atan2�֐���p���Ċp�x���v�Z
            //float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            //GAobj.transform.DORotate(new Vector3(0, 0, angle), 0, RotateMode.WorldAxisAdd);    // �U���G�t�F�N�g�̌����̏���


            GAflg = false;
            Invoke("GAflgTrue", GrabbingAttackSettings.spawnInterval);
        }

    }

}