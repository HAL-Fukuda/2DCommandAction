using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct BulletsMachineGunSettings
    {
        public GameObject forcusPoint;  //生成するPrefab
    }
    public BulletsMachineGunSettings bulletsMachineGunSettings;
    
    private GameObject playerObjBMG;  //Playerのオブジェクト
    private Vector3 playerPosBMG;  //Playerの位置
    
    private GameObject _forcusInstance;  //生成用

    private bool oneShotBMG = false;  //一回だけ呼ぶ用


    public void BulletsMachinGunInitialize()
    {
        //Playerの位置を取得
        playerObjBMG = GameObject.FindWithTag("Player");
        playerPosBMG = playerObjBMG.transform.position;
        //一回だけ呼べるように
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
