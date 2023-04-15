using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    int hp;
    int speed;

    EnemyAttack attackScript;

    public enum eEnemyType
    {
        Demon,
        Dragon,
        Goblin,
        Skelton,
        Slime,
        Soldier,
        Wolf,
        WolfMan,
        Zombie
    }
    public eEnemyType enemyType;

    public void Start()
    {
        EnemyInitialize();
        GetDamageInitialize();
    }

    void EnemyInitialize()
    {
        attackScript = GetComponent<EnemyAttack>();
    }

    public virtual void Attack()
    {
        attackScript.MeteorAttack();
        //attackScript.EnemysAttack();  //敵ごとの攻撃選択用関数
    }
}
