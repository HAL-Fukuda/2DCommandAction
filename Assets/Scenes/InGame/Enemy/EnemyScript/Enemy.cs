using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    [SerializeField][Header("ステータス用")]
    public int hp = 2;
    public int speed;

    [SerializeField][Header("攻撃用")]
    public int patternCnt = 0;          //攻撃の回数によって攻撃を切り替える用
    public int attackMode;     //攻撃のパターンを切り替える用 
    public bool patternSwitch = true;  //毎回攻撃が切り替わる用
    public int attackNum;  //攻撃切り替え用
    public bool initialized = false;  //ATBバーが溜まっているか
    public Transform actionBar;     //アクションバー
    public EnemyAttack attackScript;

    public AudioClip enemySound;  //敵の音声

    public enum eEnemyType
    {
        //ワールド１
        Slime, Wolf, NormalGoblin,    //1-1
        GoblinArcher, GoblinSoldier,  //1-2
        Grifin,                       //1-3
        Spider, Zombie,               //1-4
        Dragon,                       //1-5
        //ワールド２
        LazerMachineGunType, BulletsMachineGunType, MissileType,                         //2-1
        LazerIrradiationType, LongTimeLazerType, ExplosionMissileType,                   //2-2
        Robot,                                                                           //2-3
        MiniExplosionMissileType,  LongTimeTrackingMissileType, LongTimeMachineGunType,  //2-4
        BossRobot,                                                                       //2-5
        //ワールド３
        HumanFormWhite, OctopusFormBlue, HumanFormGray,  //3-1
        OctopusFormYellow, HumanFormSilver,              //3-2
        HumanFormGold,                                   //3-3
        OctopusFormRed, HumanFormBlack,                  //3-4
        SpaceShip,                                       //3-5
        //ワールド４
        Bakegasa, Mandragora, Kappa,  //4-1
        Kamaitachi, Saruoni, Genbu,   //4-2
        Seiryu,                       //4-3
        Youko, Tengu, Suzaku,         //4-4
        Byako,                        //4-5
        //ワールド５
        MagmaSlime, Skeleton, LizardMan,      //5-1
        Yeti, MagmaGolem, IceGolem,           //5-2
        YukiOnna,                             //5-3
        FireDragon, FrostDragon, Saramander,  //5-4
        Virus                                 //5-5 
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
        actionBar = transform.Find("ActionBar");
        attackNum = 0;
        //patternCnt = 1;
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
        //switch (attackMode)
        //{
        //    case 1:
        //        PatternSwitch();
        //        break;
        //    case 2:
        //        PatternCnt();
        //        break;
        //    case 3:
        //        PatternRandom();
        //        break;
        //}
    }

    //コピペ用
    public virtual void PatternSwitch()  //攻撃するたびに攻撃を切り替える
    {
        if (patternSwitch)
        {
            attackScript.MeteorAttack();  //攻撃を呼ぶ
            patternSwitch = false;
            //Debug.Log(patternSwitch);
        }
        else
        {
            attackScript.MeteorAttack();  //攻撃を呼ぶ
            patternSwitch = true;
        }
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

    //コピペ用
    public virtual void PatternRandom()  //ランダムで攻撃する
    {
        switch(attackNum)
        {
            case 0:
                attackScript.MeteorAttack();  //攻撃を呼ぶ
                break;
            case 1:
                attackScript.MeteorAttack();  //攻撃を呼ぶ
                break;
            case 2:
                attackScript.MeteorAttack();  //攻撃を呼ぶ
                break;
            case 3:
                attackScript.MeteorAttack();  //攻撃を呼ぶ
                break;
        }
    }

    public virtual void NextAttackNum()
    {
        attackNum = Random.Range(0, 5);
    }
}
