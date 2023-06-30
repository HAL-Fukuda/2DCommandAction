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
                text = "グリフィンの掴みかかり！";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.GrabbingAttack();
                break;
            case 1:
                text = "グリフィンのフェザーレイン！";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.FeatherAttack();
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
        spriteSwitcher.SwitchSprite(attackType);
    }
}
