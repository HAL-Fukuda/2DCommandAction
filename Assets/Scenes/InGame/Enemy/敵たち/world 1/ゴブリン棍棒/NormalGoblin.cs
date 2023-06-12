using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGoblin : Enemy
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
        string text = "ÉSÉuÉäÉìÇÃÇ±ÇÒñ_Ç±Ç§Ç∞Ç´ÅI";
        MessageWindow.Instance.SetDebugMessage(text);
        attackScript.ClubBeating();
        initialized = false;
        //base.EnemySoundPlay();
    }
}
