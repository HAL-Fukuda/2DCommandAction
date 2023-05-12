using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grifin : Enemy
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
        if(actionBar.GetComponent<ActionBarControl>().IsReady() &&
            initialized == false){
            attackScript.FeatherAttackInitialize(); // 羽飛ばし攻撃の初期化処理
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
                attackScript.FeatherAttack();
                break;
            case 1:
                attackScript.FeatherAttack();
                //掴みかかる
                break;
            case 2:
                attackScript.FeatherAttack();
                //不可避の攻撃
                break;
            case 3:
                attackScript.FeatherAttack();
                //未決定
                break;
        }
    }
}
