using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemy
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
        PatternRandom();
        initialized = false;
        //base.EnemySoundPlay();
    }

    public override void PatternRandom()
    {
        string text;

        switch (attackNum)
        {
            case 0:
                text = "ドラゴンのメテオ！";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.MeteorAttack();
                break;
            case 1:
                text = "ドラゴンの覇気！";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.InevitableAttack();
                break;
            case 2:
                text = "ドラゴンのひっかき！";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.NailAttack();
                break;
        }
    }
    public override void NextAttackNum()
    {
        attackNum = Random.Range(0, 3);
    }
}
