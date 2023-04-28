using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon3 : Enemy
{
    void Start()
    {
        base.Start();
        base.EnemySoundPlay();
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
    }

    public override void Attack()
    {
        //�G�ŗL�̍U�����Ă�
        base.EnemySoundPlay();
    }
}
