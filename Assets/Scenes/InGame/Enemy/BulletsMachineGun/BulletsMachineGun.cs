using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct BulletsMachineGunSettings
    {
        public GameObject forcusPoint;  //��������Prefab
    }
    public BulletsMachineGunSettings bulletsMachineGunSettings;
    
    private GameObject playerObjBMG;  //Player�̃I�u�W�F�N�g
    private Vector3 playerPosBMG;  //Player�̈ʒu
    
    private GameObject _forcusInstance;  //�����p

    private bool oneShotBMG = false;  //��񂾂��Ăԗp


    public void BulletsMachinGunInitialize()
    {
        //Player�̈ʒu���擾
        playerObjBMG = GameObject.FindWithTag("Player");
        playerPosBMG = playerObjBMG.transform.position;
        //��񂾂��Ăׂ�悤��
        oneShotBMG = true;
    }

    public void BulletsMachineGun()
    {
        if (oneShotBMG)
        {
            ForcusPointSpawn();
        }
        oneShotBMG = false;
    }

    

    void ForcusPointSpawn()
    {
        _forcusInstance = Instantiate(bulletsMachineGunSettings.forcusPoint, playerPosBMG, Quaternion.identity);
    }
}
