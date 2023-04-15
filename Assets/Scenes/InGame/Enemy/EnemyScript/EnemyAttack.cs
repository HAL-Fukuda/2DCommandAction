using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour //partial C++ÇÃÉNÉâÉX
{
    [System.Serializable]
    public struct AttackSettings
    {
        public GameObject prefab;
        public float spawnInterval;
        public float life;
        [SerializeField][Header("Ç¢Ç∂ÇÁÇ»Ç¢Ç≈")] public float timer;

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
        // Ç±Ç±Ç≈çUåÇÇÃëOíõÇÃèàóù
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

    public void EnemysAttack()
    {
        //Debug.Log("EnemysAttack");

        string name = EnemyMgr.instance.enemyName;

        //Debug.Log(name);

        switch (name)
        {
            case "Demon(Clone)":
                //DemonÇÃçUåÇèàóù
                //Debug.Log("DemonAttack");
                break;
            case "Dragon(Clone)":
                //
                break;
            case "Goblin(Clone)":
                //
                break;
            case "Skeleton(Clone)":
                //
                break;
            case "Slime(Clone)":
                //
                break;
            case "Soldier(Clone)":
                //
                break;
            case "Wolf(Clone)":
                //
                break;
            case "WolfMan(Clone)":
                //
                break;
            case "Zombie(Clone)":
                //
                break;
            case "Enemy":
                //Debug.Log("EnemyAttack");
                break;
        }
    }
}
