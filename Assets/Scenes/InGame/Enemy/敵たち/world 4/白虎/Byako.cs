using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Byako : Enemy
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
        if (actionBar.GetComponent<ActionBarControl>().IsReady() &&　initialized == false)
        {
            attackScript.ThunderboltAttackInitialize();
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
        string text;

        switch (attackNum)
        {
            case 0:
                text = "白虎の右爪裂！";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.ClawAttackRight();
                break;
            case 1:
                text = "白虎の落雷！";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.ThunderboltAttack();
                break;
            case 2:
                text = "白虎の左爪裂！";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.ClawAttackLeft();
                break;
        }
    }

    public override void NextAttackNum()
    {
        int attackType = 0;

        attackNum = Random.Range(0, 3);

        switch (attackNum)
        {
            case 0:
                attackType = 0;
                break;
            case 1:
                attackType = 1;
                break;
            case 2:
                attackType = 0;
                break;
        }

        //アタックアイコンを強さによって表示
        imageSwicher.SwitchSprite(attackType);
    }
}
