using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Youko : Enemy
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
        //妖狐の攻撃
        initialized = false;
        //base.EnemySoundPlay();
    }
}
