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
        //Debug.Log(attackNum);
        PatternRandom();
        initialized = false;
        //base.EnemySoundPlay();
    }

    public override void PatternRandom()
    {
        switch (attackNum)
        {
            case 0:
                //動作確認したい攻撃をここで呼んで

                break;
            case 1:
                
                break;
            case 2:
                //attackScript.BowAttack();  //二回目以降矢が出てこない
                break;
            case 3:
                
                break;
            case 4:
                
                break;
        }
    }

    public override void NextAttackNum()
    {
        attackNum = 0;  //出したい攻撃の番号を指定
        //attackNum = Random.Range(0, 2);  //攻撃をランダムで選択する
    }
}
