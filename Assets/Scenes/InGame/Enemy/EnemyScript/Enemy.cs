using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    int hp = 2;
    int speed;

    public AudioClip enemySound;  //敵の音声

    EnemyAttack attackScript;

    public enum eEnemyType
    {
        GoblinArcher,GoblinKing,GoblinSoldier,Goblin,
        Golem1,Golem2,
        Skeleton1,Skeleton2,Skeleton3,
        Spider,
        Slime1,Slime2,
        Grifin,
        Zombie,
        Demon1,Demon2,
        Troll1,Troll2,
        Dragon1,Dragon2,Dragon3,Dragon4,
        Fennel,
        Lizard,
        Suzaku,
        Machine1,Machine2,
        Wolf,
        Genbu,
        Byako,
        Seiryu,
        Ogre
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

    public void EnemySoundPlay()
    {
        GetComponent<AudioSource>().PlayOneShot(enemySound);
    }
}
