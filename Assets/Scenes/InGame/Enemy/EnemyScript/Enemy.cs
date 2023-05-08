using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    [SerializeField][Header("ステータス用")]
    public int hp = 2;
    public int speed;

    [SerializeField][Header("攻撃用")]
    //public int attackNum;  //2種類以上の攻撃がある敵用
    public int patternCnt = 0;          //攻撃の回数によって攻撃を切り替える用
    public bool attackMode = false;     //攻撃のパターンを切り替える用 
    public bool patternSwitch = false;  //毎回攻撃が切り替わる用
    public EnemyAttack attackScript;

    public AudioClip enemySound;  //敵の音声

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
        patternCnt = 1;
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

    public void AttackMode()
    {
        if (attackMode)
        {
            PatternSwitch();
        }
        else
        {
            PatternCnt();
        }
    }

    //コピペ用
    public virtual void PatternSwitch()  //攻撃するたびに攻撃を切り替える
    {
        //if (patternSwitch)
        //{
        //    attackScript.MeteorAttack();  //攻撃を呼ぶ
        //    patternSwitch = false;
        //    //Debug.Log(patternSwitch);
        //}
        //else
        //{
        //    attackScript.MeteorAttack();  //攻撃を呼ぶ
        //}
    }

    //コピペ用
    public virtual void PatternCnt()  //２回に１回別の攻撃をはさむ
    {
        ////Debug.Log("Cnt");
        //if (patternCnt <= 2)
        //{
        //    attackScript.MeteorAttack();  //攻撃を呼ぶ
        //    //Debug.Log("一つ目の攻撃");
        //    //Debug.Log(patternCnt);
        //}
        //else if (patternCnt >= 3)
        //{
        //    attackScript.MeteorAttack();  //攻撃を呼ぶ
        //    //Debug.Log("二つ目の攻撃");
        //    patternCnt = 1;
        //}

        //patternCnt++;
    }
}
