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
        Demon,Demon1,Demon2,
        Dragon,Dragon1,Dragon2,
        Goblin,GoblinSoldier, GoblinArcher, GoblinKing,
        Golem1,Golem2,
        Skeleton, Skeleton1, Skeleton2,
        Slime,
        Soldier,
        Wolf,
        WolfMan,
        Zombie,
        Fennel,
        Lizard,
        Troll1,Troll2,
        Machine1,Machine2,
        Genbu,Suzaku,Seiryu,Byako
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
