using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Yukionna : Enemy
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
            attackScript.ArareAttackInitialize();
            attackScript.IceThornInitialize();
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
                text = "雪女のアイシクルレイ！";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.IceThorn();
                break;
            case 1:
                text = "雪女のヘイルストーム！";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.ArareAttack();
                break;
        }
    }

    public override void NextAttackNum()
    {
        int attackType = 0;

        attackNum = Random.Range(0, 2);

        switch (attackNum)
        {
            case 0:
                attackType = 0;
                break;
            case 1:
                attackType = 1;
                break;
        }

        //アタックアイコンを強さによって表示
        imageSwicher.SwitchSprite(attackType);
    }
}
