using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    int hp;
    int speed;

    EnemyAttack attackScript;

    void Start()
    {
        EnemyInitialize();
        GetDamageInitialize();
    }

    void EnemyInitialize()
    {
        attackScript = GetComponent<EnemyAttack>();
    }

    public virtual void Attack()
    {
        attackScript.MeteorAttack();
    }
}
