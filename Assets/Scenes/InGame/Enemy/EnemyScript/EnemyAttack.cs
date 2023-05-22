using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour //partial C++�̃N���X
{
    [System.Serializable]
    public struct AttackSettings
    {
        public GameObject prefab;
        public float spawnInterval;
        public float life;
        [SerializeField][Header("������Ȃ���")] public float timer;

        public AttackSettings(GameObject prefab, float spawnInterval, float life)
        {
            this.prefab = prefab;
            this.spawnInterval = spawnInterval;
            this.life = life;
            this.timer = 0f;
        }
    }

    private bool isReady = false;

    public void EnemyAttackInitialize()
    {
        isReady = false;
        // �����ōU���̑O���̏���
        StartShake();
    }

    // �I������
    // �U�����I�������Ăяo��
    public void EnemyAttackFinalize()
    {
        isReady = false;
    }

    void EnemyAttackUpdate()
    {
        //MeteorAttack();
        SidewaysAttack();
        //EnemysAttack();  //�ŏI���ꂾ���ɂ���
    }

    public bool IsReady()
    {
        return isReady;
    }

    public void IsReadyOn()
    {
        isReady = true;
    }

    void Update()
    {
        
        // SideVanishAttack�Ɏg�����
        if (rgd != null)
        {
            // ���x�̏���ݒ�
            if (rgd.velocity.magnitude > SVAspeed)
            {
                rgd.velocity = rgd.velocity.normalized * SVAspeed;  // �ő呬�x��݂���
            }
        }

        // GrabbingAttack�Ɏg�����
        if (GArgd != null)
        {
            // ���x�̏���ݒ�
            if (GArgd.velocity.magnitude > GAspeed)
            {
                GArgd.velocity = GArgd.velocity.normalized * GAspeed;  // �ő呬�x��݂���
            }
        }

        // SpiderNeedle�Ɏg�����
        if (SNrgd != null)
        {
            // ���x�̏���ݒ�
            if (SNrgd.velocity.magnitude > SNspeed)
            {
                SNrgd.velocity = SNrgd.velocity.normalized * SNspeed;  // �ő呬�x��݂���
            }
        }
        // FoxOnibi�Ɏg�����
        if (FOrgd != null)
        {
            // ���x�̏���ݒ�
            if (FOrgd.velocity.magnitude > FOspeed)
            {
                FOrgd.velocity = FOrgd.velocity.normalized * FOspeed;  // �ő呬�x��݂���
            }
        }

        // RockThrowing�Ɏg�����
        if (RTrgd != null)
        {
            // ���x�̏���ݒ�
            if (RTrgd.velocity.magnitude > RTspeed)
            {
                RTrgd.velocity = RTrgd.velocity.normalized * RTspeed;  // �ő呬�x��݂���
            }
        }

        // FlameSplash�Ɏg�����
        if (FSrgd != null)
        {
            // ���x�̏���ݒ�
            if (FSrgd.velocity.magnitude > FSspeed)
            {
                FSrgd.velocity = FSrgd.velocity.normalized * FSspeed;  // �ő呬�x��݂���
            }
        }

        // BoneThrow�Ɏg�����
        if (BTrgd != null)
        {
            // ���x�̏���ݒ�
            if (BTrgd.velocity.magnitude > BTspeed)
            {
                BTrgd.velocity = BTrgd.velocity.normalized * BTspeed;  // �ő呬�x��݂���
            }
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            FirePunch();
        }
    }

    //public Enemy.eEnemyType EnemysAttack(Enemy.eEnemyType enemyType)
    //{
    //    //Debug.Log("EnemysAttack");
    //    //GameObject attackEnemy;  //�U�����Ă���G

    //    //attackEnemy = GameObject.FindWithTag("Enemy");
    //    //string name = attackEnemy.EnemyType;

    //    //Debug.Log(enemyType);

    //    switch (enemyType)
    //    {
    //        case Enemy.eEnemyType.Demon:
    //            //Demon�̍U������
    //            break;
    //    }
    //}
}
