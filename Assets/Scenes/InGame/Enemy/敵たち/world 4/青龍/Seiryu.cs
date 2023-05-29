using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seiryu : Enemy
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
        switch (attackNum)
        {
            case 0:
                attackScript.TorrentAttack();
                break;
            case 1:
                attackScript.WofwaterAttack();
                break;
        }
    }

    public override void NextAttackNum()
    {
        //attackNum = 1;
        attackNum = Random.Range(0, 2);
    }
}
