using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    [SerializeField][Header("ステータス用")]
    public int hp = 2;

    [SerializeField][Header("攻撃用")]
    public int attackNum;  //攻撃切り替え用
    public bool initialized = false;  //ATBバーが溜まっているか
    public Transform actionBar;     //アクションバー
    public EnemyAttack attackScript;
    public GameObject cd;  //子オブジェクト
    public GameObject gcd;  //孫オブジェクト
    public ImageSwicher imageSwicher;//孫オブジェクトのスクリプト

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
        GetAttackIconAndScript();
    }

    void EnemyInitialize()
    {
        attackScript = GetComponent<EnemyAttack>();
        actionBar = transform.Find("ActionBar");
    }

    public int SendEnemyHp()
    {
        return hp;
    }

    public virtual void Attack()
    {
        attackScript.MeteorAttack();
    }

    public void EnemySoundPlay()
    {
        GetComponent<AudioSource>().PlayOneShot(enemySound);
    }

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
        int attackType = 0;

        attackNum = Random.Range(0, 5);

        switch (attackNum)
        {
            case 0:
                attackType = 0;  //弱い攻撃の時
                break;
            case 1:
                attackType = 1;  //強い攻撃の時
                break;
        }

        //アタックアイコンを強さによって表示
        imageSwicher.SwitchSprite(attackType);
    }

    void GetAttackIconAndScript()
    {
        //子オブジェクトの取得
        cd = transform.GetChild(2).gameObject;

        //孫オブジェクトの取得
        gcd = transform.GetChild(0).gameObject;

        //子オブジェクトのスクリプトを取得
        imageSwicher = gcd.GetComponent<ImageSwicher>();
    }
}
