using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyMgr : MonoBehaviour
{
    public GameObject GetEnemyData()
    {
        if(enemy != null)
        {
            return enemy;
        }

        Debug.Log("enemy����������Ă��܂���B");
        return null;
    }
}
