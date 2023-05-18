using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTester : Enemy
{
    void Start()
    {
        base.Start();
        //base.EnemySoundPlay();
    }

    void Update()
    {
        if (isFadeIn)
        {
            base.FadeIn();
        }
        if (isFadeOut)
        {
            base.FadeOut();
        }
        if (killFlag)
        {
            base.DestroyEffectSpawn();
        }
        // ゲージがたまったら
        if (actionBar.GetComponent<ActionBarControl>().IsReady() && initialized == false)
        {
            initialized = true;
        }
    }

    public override void Attack()
    {
        Debug.Log(attackNum);
        PatternRandom();
        initialized = false;
        //base.EnemySoundPlay();
    }

    public override void PatternRandom()
    {
        switch (attackNum)
        {
            case 0:
                attackScript.BowAttack();  //二回目以降矢が出てこない
                break;
            case 1:
                
                break;
            case 2:
                //attackScript.IcicleAttack();  //要改善
                break;
            case 3:
                attackScript.GrabbingAttack();
                break;
            case 4:
                //attackScript.SnowBallAttack();  //要改善
                break;
        }
    }

    public override void NextAttackNum()
    {
        attackNum = 3;
        //attackNum = Random.Range(0, 2);
    }
}
