using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings ZBUpperSettings;
    public AttackSettings ZBUnderSettings;

    private Vector3 ZBUpperPosition;     // 攻撃発生位置
    private Vector3 ZBUnderPosition;

    private GameObject ZBobjUpper;
    private GameObject ZBobjUnder;

    private WBCollision zbCollision;

    private bool ZBflg = true;

    void GetPlayerPositionToZB()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        // 攻撃判定のスポーン位置設定
        ZBUpperPosition = PlayerObject.transform.position;
        ZBUpperPosition.y += 3.0f;
        ZBUpperPosition.z = 0.0f;

        ZBUnderPosition = PlayerObject.transform.position;
        ZBUnderPosition.y -= 2.0f;
        ZBUnderPosition.z = 0.0f;

        Debug.Log(ZBUpperPosition);
    }

    void ZombieBitingTooth()
    {
        ZBobjUpper.transform.DOMove(new Vector3(ZBUpperPosition.x, ZBUpperPosition.y - 2.5f, 0), 1.0f);
        ZBobjUnder.transform.DOMove(new Vector3(ZBUnderPosition.x, ZBUnderPosition.y + 2, 0), 1.0f);

        //zbCollision.GetComponent<WBCollision>().ToggleCollider(true);

        Invoke("ZBobjDestroy", 1.5f);
    }

    void ZBobjDestroy()
    {
        //zbCollision.GetComponent<WBCollision>().ToggleCollider(false);
        Destroy(ZBobjUpper);
        Destroy(ZBobjUnder);
    }

    void ZBflgTrue()
    {
        ZBflg = true;
    }

    public void ZombieBiting()
    {

        if (ZBflg)
        {

            GetPlayerPositionToZB();

            spawnPos = new Vector3(ZBUpperPosition.x, ZBUpperPosition.y, 0.0f);
            ZBobjUpper = Instantiate(ZBUpperSettings.prefab, spawnPos, Quaternion.identity);

            spawnPos = new Vector3(ZBUnderPosition.x, ZBUnderPosition.y, 0.0f);
            ZBobjUnder = Instantiate(ZBUnderSettings.prefab, spawnPos, Quaternion.identity);

            Invoke("ZombieBitingTooth", 1.0f);

            ZBflg = false;
            Invoke("ZBflgTrue", ZBUpperSettings.spawnInterval + ZBUnderSettings.spawnInterval);
        }
    }


    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        ZombieBiting();
    //    }
    //}
}
