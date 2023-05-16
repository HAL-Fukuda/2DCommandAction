using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings TongueLickingSettings;
    private Vector3 TLPosition;     // 攻撃発生位置
    private Rigidbody2D TLrgd, TLrgd2;

    private GameObject TLobj, TLobj2;
    private int TLCount = 0;

    private bool TLflg = true;


    void GetPlayerPositionToTL()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        TLPosition = PlayerObject.transform.position;
        TLPosition.y = -3.5f;
        TLPosition.z = 0.0f;
        //Debug.Log(CBPosition);
    }

    void TLobjDestroy()
    {
        if (TLCount == 0)
        {
            TLCount = 1;
            TLflg = true;
            Debug.Log(TLCount);
            Destroy(TLobj);
        }
        else if(TLCount == 1) 
        {
            Invoke("TLflgTrue", TongueLickingSettings.spawnInterval);   // 数秒後にオブジェクトを消す
            Destroy(TLobj2);
        }
        
    }

    void TLCountReset()
    {
        TLCount = 0;
    }

    void TLflgTrue()
    {
        TLflg = true;
        TLCountReset();
    }

    void TLobjLicking()
    {
        if (TLCount == 0)
        {
            TLrgd.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * 1300.0f);  // 上方向に力をかける
        }
        else if (TLCount == 1)
        {
            TLrgd2.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * 1300.0f);  // 上方向に力をかける
        }
    }

    public void TongueLicking()
    {
        
        if (TLflg)
        {
            TLflg = false;


            if (TLCount == 0) 
            {
                GetPlayerPositionToTL();

                spawnPos = new Vector3(TLPosition.x, TLPosition.y, 0.0f);
                TLobj = Instantiate(TongueLickingSettings.prefab, spawnPos, Quaternion.identity);
                TLrgd = TLobj.GetComponent<Rigidbody2D>();

                // 
                TLobj.transform.DOPath(
            path: new Vector3[] { new Vector3(TLPosition.x + 1, TLPosition.y + 0.0f, 0),
                                 new Vector3(TLPosition.x + 1, TLPosition.y - 0.0f, 0),
                                 new Vector3(TLPosition.x - 1, TLPosition.y + 0.0f, 0),
                                 new Vector3(TLPosition.x - 1, TLPosition.y - 0.0f, 0),
                                 new Vector3(TLPosition.x, TLPosition.y, 0)}, //移動するポイント
            duration: 1.0f, //移動時間
            pathType: PathType.CatmullRom //移動するパスの種類
            ).OnComplete(TLobjLicking);


                Invoke("TLobjDestroy", 2.0f);   // 数秒後にオブジェクトを消す
            }

            if (TLCount == 1)
            {
                GetPlayerPositionToTL();

                spawnPos = new Vector3(TLPosition.x, TLPosition.y, 0.0f);
                TLobj2 = Instantiate(TongueLickingSettings.prefab, spawnPos, Quaternion.identity);
                TLrgd2 = TLobj2.GetComponent<Rigidbody2D>();

                // 
                TLobj2.transform.DOPath(
            path: new Vector3[] { new Vector3(TLPosition.x + 1, TLPosition.y + 0.0f, 0),
                                 new Vector3(TLPosition.x + 1, TLPosition.y - 0.0f, 0),
                                 new Vector3(TLPosition.x - 1, TLPosition.y + 0.0f, 0),
                                 new Vector3(TLPosition.x - 1, TLPosition.y - 0.0f, 0),
                                 new Vector3(TLPosition.x, TLPosition.y, 0)}, //移動するポイント
            duration: 1.0f, //移動時間
            pathType: PathType.CatmullRom //移動するパスの種類
            ).OnComplete(TLobjLicking);


                Invoke("TLobjDestroy", 2.0f);   // 数秒後にオブジェクトを消す
            }
        }
    }
}
