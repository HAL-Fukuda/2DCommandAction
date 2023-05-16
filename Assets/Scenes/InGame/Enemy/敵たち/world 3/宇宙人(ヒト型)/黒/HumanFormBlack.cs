using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanFormBlack : Enemy
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
            initialized = true;
        }
    }

    public override void Attack()
    {
        //ÉqÉgå^ÅiçïÅjÇÃçUåÇ
        initialized = false;
        //base.EnemySoundPlay();
    }
}
