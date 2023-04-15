using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings ClubSwingSettings;
    private Vector3 CSPosition;     // 攻撃発生位置
    private Rigidbody2D CSrgd;

    public float SwingSpeedSeconds;

    private GameObject CSobj;

    private GameObject csCollision;


    void GetPlayerPositionToCS()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        Transform myObjectTransform = player1.GetComponent<Transform>();

        // 攻撃判定のスポーン位置設定
        CSPosition = myObjectTransform.position;

        if (CSPosition.x < 0)
        {
            CSPosition.x = 10.0f;
        }
        else
        {
            CSPosition.x = -10.0f;
        }
        CSPosition.y += 1.0f;
        CSPosition.z = 0.0f;
        //Debug.Log(CSPosition);
    }

    void CSobjSwing()
    {
        if (CSPosition.x < 0)   // 攻撃が左湧きの時
        {
            csCollision.GetComponent<CSCollision>().SwingSoundPlay();
            CSobj.transform.DOMove(new Vector3(15, CSPosition.y, 0), SwingSpeedSeconds)
                .OnComplete(CSobjDestroy);
            
        }
        else
        {
            csCollision.GetComponent<CSCollision>().SwingSoundPlay();
            CSobj.transform.DOMove(new Vector3(-15, CSPosition.y, 0), SwingSpeedSeconds)
                .OnComplete(CSobjDestroy);
            
        }
    }

    void CSobjDestroy()
    {
        Destroy(CSobj);
    }

    void ClubSwing()
    {
        GetPlayerPositionToCS();
        spawnPos = new Vector3(CSPosition.x, CSPosition.y, 0.0f);
        CSobj = Instantiate(ClubSwingSettings.prefab, spawnPos, Quaternion.identity);
        CSrgd = CSobj.GetComponent<Rigidbody2D>();

        csCollision = GameObject.Find("ClubSwing(Clone)");

        CSobj.transform.DOPath(
    path: new Vector3[] {        new Vector3(CSPosition.x + 0.3f, CSPosition.y + 2, 0),
                                 new Vector3(CSPosition.x - 0.3f, CSPosition.y + 2, 0),
                                 new Vector3(CSPosition.x + 0.3f, CSPosition.y - 2, 0),
                                 new Vector3(CSPosition.x - 0.3f, CSPosition.y - 2, 0),
                                 new Vector3(CSPosition.x, CSPosition.y, 0)}, //移動するポイント
    duration: 3f, //移動時間
    pathType: PathType.CatmullRom //移動するパスの種類
    ).OnComplete(CSobjSwing);

        //Invoke("CSobjDestroy", 3.5f);   // 数秒後にオブジェクトを消す
    }


    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        ClubSwing();
    //    }
    //}
}
