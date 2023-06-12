using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime: Enemy
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
        string text = "スライムのねばねばこうげき！";
        MessageWindow.Instance.SetDebugMessage(text);
        attackScript.BindAttack();
        initialized = false;
        //base.EnemySoundPlay();
    }
}
