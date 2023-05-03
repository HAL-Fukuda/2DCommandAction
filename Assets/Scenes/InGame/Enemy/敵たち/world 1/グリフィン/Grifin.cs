using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grifin : Enemy
{
    private Transform actionBar; // アクションバー
    bool initialized = false;

    void Start()
    {
        actionBar = transform.Find("ActionBar");
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
        //敵固有の攻撃を呼ぶ
        attackScript.FeatherAttack();
        initialized = false;
        //base.EnemySoundPlay();
    }
}
