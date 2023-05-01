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

        if (Input.GetKeyUp(KeyCode.B))
        {
            //ZombieBiting();
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
