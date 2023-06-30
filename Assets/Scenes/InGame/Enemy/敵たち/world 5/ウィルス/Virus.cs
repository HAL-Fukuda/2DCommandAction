using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Enemy
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
            attackScript.SporeInitialize();
            attackScript.HomingenergyInitialize();
            attackScript.HomingBombMissileInitialize();
            attackScript.ThunderboltAttackInitialize();
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
                text = "エンバグ";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.Spore();
                break;
            case 1:
                text = "コード:フェイカー【ドラゴン】";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.InevitableAttack();
                break;
            case 2:
                text = "コード:フェイカー【ボスロボット】";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.HomingBombMissileAttack();
                break;
            case 3:
                text = "コード:フェイカー【宇宙船】";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.HomingenergyAttack();
                break;
            case 4:
                text = "コード:フェイカー【白虎】";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.ThunderboltAttack();
                break;
        }
    }

    public override void NextAttackNum()
    {
        int attackType = 0;

        attackNum = Random.Range(0, 5);

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
            case 3:
                attackType = 0;
                break;
            case 4:
                attackType = 1;
                break;
        }

        //アタックアイコンを強さによって表示
        spriteSwitcher.SwitchSprite(attackType);
    }
}
