using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings WBUpperSettings;
    public AttackSettings WBUnderSettings;

    private Vector3 WBUpperPosition;     // 攻撃発生位置
    private Vector3 WBUnderPosition;

    private GameObject WBobjUpper;
    private GameObject WBobjUnder;

    private WBCollision wbCollision;

    void GetPlayerPositionToWB()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        Transform myObjectTransform = player1.GetComponent<Transform>();



        // 攻撃判定のスポーン位置設定
        WBUpperPosition = myObjectTransform.position;
        WBUpperPosition.y += 3.0f;
        WBUpperPosition.z = 0.0f;

        WBUnderPosition = myObjectTransform.position;
        WBUnderPosition.y -= 2.0f;
        WBUnderPosition.z = 0.0f;

        Debug.Log(WBUpperPosition);
    }

    void BitingTooth()
    {
        WBobjUpper.transform.DOMove(new Vector3(WBUpperPosition.x, WBUpperPosition.y - 2, 0), 0.2f);
        WBobjUnder.transform.DOMove(new Vector3(WBUnderPosition.x, WBUnderPosition.y + 2, 0), 0.2f);

        wbCollision.GetComponent<WBCollision>().ToggleCollider(true);

        Invoke("WBobjDestroy", 0.5f);
    }

    void WBobjDestroy()
    {
        wbCollision.GetComponent<WBCollision>().ToggleCollider(false);
        Destroy(WBobjUpper);
        Destroy(WBobjUnder);
    }

    public void WolfBiting()
    {
        GetPlayerPositionToWB();

        spawnPos = new Vector3(WBUpperPosition.x, WBUpperPosition.y, 0.0f);
        WBobjUpper = Instantiate(WBUpperSettings.prefab, spawnPos, Quaternion.identity);

        spawnPos = new Vector3(WBUnderPosition.x, WBUnderPosition.y, 0.0f);
        WBobjUnder = Instantiate(WBUnderSettings.prefab, spawnPos, Quaternion.identity);



        Invoke("BitingTooth", 1.0f);
    }


    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        WolfBiting();
    //    }
    //}
}
