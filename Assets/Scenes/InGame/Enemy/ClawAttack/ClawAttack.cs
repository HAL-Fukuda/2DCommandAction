using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    

    // プレイヤーオブジェクトを参照する
    //public GameObject player1;  // プレイヤーの位置取得用

    public AttackSettings ClawComingAttackSettings;
    public AttackSettings ClawAttackSettings;

    // オブジェクトの位置を取得する
    private Vector3 CAPosition;

    private bool CAflg = true;

    void RightCA()
    {

        CAPosition = new Vector3(6, 0, 0);

        Debug.Log("ポジション取得");
    }

    void LeftCA()
    {

        CAPosition = new Vector3(-6, 0, 0);

        Debug.Log("ポジション取得");
    }

    void premonitionCA()
    {

        // プレイヤーの位置に予兆発生
        spawnPos = new Vector3(CAPosition.x, 0f, 0f);
        GameObject obj = Instantiate(ClawComingAttackSettings.prefab, spawnPos, Quaternion.identity);
        obj.transform.DOMoveY(
                0, //移動量
                2.5f // 演出時間
            ).OnComplete(() =>
            {
                RealClaw();
                Destroy(obj);
                
            });
    }

    void RealClaw()
    {
        // プレイヤーの位置にビーム発生
        //Vector3 spawnPos = new Vector3(objectPosition.x, 0f, 0f);
        GameObject obj1 = Instantiate(ClawAttackSettings.prefab, spawnPos, Quaternion.identity);
        obj1.transform.DOMoveY(
                0, //移動量
                1.5f // 演出時間
            ).OnComplete(() =>
            {
                Destroy(obj1);
            });
    }

    void CAflgTrue()
    {
        CAflg = true;
        Debug.Log("フラグがトゥルー");
    }

    public void ClawAttackRight()
    {
        if (CAflg)
        {
            RightCA();
            premonitionCA();

            CAflg = false;
            Invoke("CAflgTrue", ClawComingAttackSettings.spawnInterval + ClawAttackSettings.spawnInterval);
        }
        //Debug.Log(objectPosition);
    }

    public void ClawAttackLeft()
    {
        if (CAflg)
        {
            LeftCA();
            premonitionCA();

            CAflg = false;
            Invoke("CAflgTrue", ClawComingAttackSettings.spawnInterval + ClawComingAttackSettings.spawnInterval);
        }
        //Debug.Log(objectPosition);
    }


    // Start is called before the first frame update


    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        SatelliteBeam();
    //    }
    //}
}