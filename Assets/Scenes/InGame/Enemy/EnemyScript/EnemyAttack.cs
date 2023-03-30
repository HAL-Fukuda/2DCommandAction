using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour //partial C++‚ÌƒNƒ‰ƒX
{
    public Transform playerTransform;

    void EnemyAttackInitialize()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void EnemyAttackUpdate()
    {
        //MeteorAttack();
        SidewaysAttack();
    }
}
