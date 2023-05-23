using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings ClubBeatingSettings;
    private Vector3 CBPosition;     // 攻撃発生位置
    private Rigidbody2D CBrgd;

    private GameObject CBobj;

    private bool CBflg = true;
    

    void GetPlayerPositionToCB()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        CBPosition = PlayerObject.transform.position;
        CBPosition.y = 6.0f;
        CBPosition.z = 0.0f;
        //Debug.Log(CBPosition);
    }

    void CBobjDestroy()
    {
        Destroy(CBobj);
    }

    void CBflgTrue()
    {
        CBflg = true;
    }

    void CBobjBeating()
    {
        CBrgd.AddForce(new Vector3(0.0f, -1.0f, 0.0f) * 1000.0f);  // 下方向に力をかける
        Invoke("CBobjDestroy", 0.5f);   // 数秒後にオブジェクトを消す
    }

    public void ClubBeating()
    {
        //ClubBeatingSettings.timer += Time.deltaTime;

        //if (ClubBeatingSettings.timer >= ClubBeatingSettings.spawnInterval)
        if(CBflg)
        {
            ClubBeatingSettings.timer = 0f;

            GetPlayerPositionToCB();

            spawnPos = new Vector3(CBPosition.x, CBPosition.y, 0.0f);
            CBobj = Instantiate(ClubBeatingSettings.prefab, spawnPos, Quaternion.identity);
            CBrgd = CBobj.GetComponent<Rigidbody2D>();

            // 
            CBobj.transform.DOPath(
        path: new Vector3[] { new Vector3(CBPosition.x + 2, CBPosition.y + 0.3f, 0),
                                 new Vector3(CBPosition.x + 2, CBPosition.y - 0.3f, 0),
                                 new Vector3(CBPosition.x - 2, CBPosition.y + 0.3f, 0),
                                 new Vector3(CBPosition.x - 2, CBPosition.y - 0.3f, 0),
                                 new Vector3(CBPosition.x, CBPosition.y, 0)}, //移動するポイント
        duration: 3f, //移動時間
        pathType: PathType.CatmullRom //移動するパスの種類
        ).OnComplete(CBobjBeating);


            

            CBflg = false;
            Invoke("CBflgTrue", ClubBeatingSettings.spawnInterval);
        }
    }


    //Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        ClubBeating();
    //    }
    //}
}
