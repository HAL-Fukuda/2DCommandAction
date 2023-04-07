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

    void EnemyAttackUpdate()
    {
        //MeteorAttack();
        SidewaysAttack();
    }

    public bool IsReady()
    {
        return isReady;
    }

    public void IsReadyOn()
    {
        isReady = true;
    }
}
