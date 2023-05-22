using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]

    public struct BulletsMachineGunAttackSettings
    {
        public GameObject focusPoint;
    }
    public BulletsMachineGunAttackSettings bulletsMachineGunAttackSettings;

    private GameObject playerObjBmg;
    private Vector3 playerPosBmg;

    private GameObject _focusInstance;

    private bool onceShotBmg = false;
    
    public void BulletsMachineGunAttackInitialize()
    {
        playerObjBmg = GameObject.FindWithTag("Player");
        playerPosBmg = playerObjBmg.transform.position;

        onceShotBmg = true;
    }

    public void BulletsMachineGunAttack()
    {
        if (onceShotBmg)
        {
            ForcusPointSpawn();
        }

        onceShotBmg = false;
    }

    void ForcusPointSpawn()
    {
        _focusInstance = Instantiate(bulletsMachineGunAttackSettings.focusPoint, playerPosBmg, Quaternion.identity);
    }
}
