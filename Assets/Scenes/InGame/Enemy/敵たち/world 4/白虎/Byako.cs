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
        // ÉQÅ[ÉWÇ™ÇΩÇ‹Ç¡ÇΩÇÁ
        if (actionBar.GetComponent<ActionBarControl>().IsReady() &&Å@initialized == false)
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
                
                break;
            case 1:
                
                break;
            case 2:
                
                break;
        }
    }

    public override void NextAttackNum()
    {
        attackNum = 1;
        attackNum = Random.Range(0, 3);
    }
}
