using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSoldier : Enemy
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
        // �Q�[�W�����܂�����
        if (actionBar.GetComponent<ActionBarControl>().IsReady() && initialized == false)
        {
            initialized = true;
        }
    }

    public override void Attack()
    {
        //Debug.Log(attackNum);
        PatternRandom();
        initialized = false;
        //base.EnemySoundPlay();
    }

    public override void PatternRandom()
    {
        switch (attackNum)
        {
            case 0:
                attackScript.SlashingSword();
                break;
            case 1:
                attackScript.SlashingSword();
                break;
            case 2:
                attackScript.SlashingSword();
                break;
            case 3:
                attackScript.SlashingSword();
                break;
            case 4:
                attackScript.SlashingSword();
                break;
        }
    }
}
