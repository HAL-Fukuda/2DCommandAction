using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
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
        string text = "くもの糸こうげき！";
        MessageWindow.Instance.SetDebugMessage(text);
        attackScript.SpiderNeedle();
        initialized = false;
        //base.EnemySoundPlay();
    }
}
