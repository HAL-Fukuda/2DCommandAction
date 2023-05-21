using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings FirePunchSettings;
    private Vector3 FPPosition;     // 攻撃発生位置
    private Rigidbody2D FPrgd;

    private GameObject FPobj;

    private bool FPflg = true;

    public bool PunchIsFire;
    private float FPTweak = 0.0f;


    void GetPlayerPositionToFP()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        FPPosition = PlayerObject.transform.position;
        FPPosition.y = 6.0f;
        FPPosition.z = 0.0f;
        //Debug.Log(FPPosition);
    }

    void FPobjDestroy()
    {
        Destroy(FPobj);
    }

    void FPflgTrue()
    {
        FPflg = true;
    }

    void FPobjBeating()
    {
        FPrgd.AddForce(new Vector3(0.0f, -1.0f, 0.0f) * 1000.0f);  // 下方向に力をかける

        Invoke("FPobjDestroy", 0.5f);   // 数秒後にオブジェクトを消す
        Invoke("FPflgTrue", FirePunchSettings.spawnInterval);
    }

    public void FirePunch()
    {
        if (PunchIsFire)
        {
            FPTweak = 1.5f;
        }
        else
        {
            FPTweak = -1.3f;
        }

        if (FPflg)
        {

            GetPlayerPositionToFP();

            spawnPos = new Vector3(FPPosition.x, FPPosition.y, 0.0f);
            FPobj = Instantiate(FirePunchSettings.prefab, spawnPos, Quaternion.identity);

            // リジットボディぶち込み
            FPrgd = FPobj.GetComponent<Rigidbody2D>();


            // パンチの予兆の動き
            FPobj.transform.DOMove(new Vector3(FPPosition.x + 2, FPPosition.y + 0.3f, 0), 0.3f).SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    GetPlayerPositionToFP();

                    FPobj.transform.DOMove(new Vector3(FPPosition.x + 2, FPPosition.y - 0.3f, 0), 0.3f).SetEase(Ease.Linear)
                        .OnComplete(() =>
                         {
                            GetPlayerPositionToFP();

                             FPobj.transform.DOMove(new Vector3(FPPosition.x - 2, FPPosition.y + 0.3f, 0), 0.3f).SetEase(Ease.Linear)
                                   .OnComplete(() =>
                                {
                                 GetPlayerPositionToFP();

                                    FPobj.transform.DOMove(new Vector3(FPPosition.x - 2, FPPosition.y - 0.3f, 0), 0.3f).SetEase(Ease.Linear)
                                                .OnComplete(() =>
                                            {
                                                 GetPlayerPositionToFP();

                                                FPobj.transform.DOMove(new Vector3(FPPosition.x + FPTweak, FPPosition.y, 0), 0.3f).SetEase(Ease.Linear)
                                                    .OnComplete(FPobjBeating);
                                            });
                                });
                         });
                });

            FPflg = false;
            
        }
    }


}
