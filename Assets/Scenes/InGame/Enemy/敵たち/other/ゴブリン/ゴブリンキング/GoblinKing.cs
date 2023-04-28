using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinKing : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        base.EnemySoundPlay();
    }

    // Update is called once per frame
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
    }

    public void GoblinKingAttack()
    {
        //EnemySoundPlay();
    }
}
