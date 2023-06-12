using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinArcher : Enemy
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
        if (actionBar.GetComponent<ActionBarControl>().IsReady() &&
            initialized == false)
        {
            attackScript.BowAttackInitialize(); // 弓矢攻撃の初期化処理
            initialized = true;
        }
    }

    public override void Attack()
    {
        string text = "ゴブリンの弓矢こうげき！";
        MessageWindow.Instance.SetDebugMessage(text);
        attackScript.BowAttack();
        initialized = false;
        //base.EnemySoundPlay();
    }
}
