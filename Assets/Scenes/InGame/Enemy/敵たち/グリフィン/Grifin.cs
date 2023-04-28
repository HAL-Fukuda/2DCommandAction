using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grifin : Enemy
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
    }

    public override void Attack()
    {
        //�G�ŗL�̍U�����Ă�
        base.EnemySoundPlay();
    }
}
