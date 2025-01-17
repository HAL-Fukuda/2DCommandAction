using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct ArareAttackSettings
    {
        public ParticleSystem ararePrefab;
    }
    public ArareAttackSettings arareAttackSettings;

    private GameObject enemyObj;
    private Vector3 enemyPos;
    private ParticleSystem _arareObjInstance;
    private bool arareCheck = false;

    public void ArareAttackInitialize()
    {
        arareCheck = true;
        enemyObj = GameObject.FindWithTag("Enemy");
        enemyPos = enemyObj.transform.position;
        //Debug.Log(arareCheck);
    }

    public void ArareAttack()
    {
        if (arareCheck == true)
        {
            ArareSpawn();
        }
        
        arareCheck = false;
    }

    void ArareSpawn()
    {
        _arareObjInstance = Instantiate(arareAttackSettings.ararePrefab, enemyPos,Quaternion.identity);
        Debug.Log("Spawn");
    }
}
