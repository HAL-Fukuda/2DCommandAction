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
        // ÉQÅ[ÉWÇ™ÇΩÇ‹Ç¡ÇΩÇÁ
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
                text = "";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.InevitableAttack();
                break;
            case 1:
                text = "";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.Spore();
                break;
            case 2:
                text = "";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.HomingBombMissileAttack();
                break;
            case 3:
                text = "";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.HomingenergyAttack();
                break;
            case 4:
                text = "";
                MessageWindow.Instance.SetDebugMessage(text);
                attackScript.ThunderboltAttack();
                break;
        }
    }

    public override void NextAttackNum()
    {
        attackNum = Random.Range(0, 5);
    }
}
