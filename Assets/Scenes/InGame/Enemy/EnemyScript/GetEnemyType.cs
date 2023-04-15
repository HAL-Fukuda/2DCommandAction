using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyMgr : MonoBehaviour
{
    private GameObject enemyObj;

    public static EnemyMgr instance;
    public string enemyName;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void GetEnemyTypeInitialize()
    {
        enemyObj = GameObject.FindWithTag("Enemy");
        enemyName = enemyObj.name;
    }
}
