using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed = 1;  //移動速度
    public float jumpSpeed = 1;  //ジャンプ距離

    public GameObject PunchObj; //パンチのゲームオブジェクト

    private Vector3 playerPos;  //プレイヤーのポジション
    private float x;            //x方向のImputの値
    private Rigidbody rb;       

    Vector3 punchPoint;         //PunchObjを出す位置

    // Start is called before the first frame update
    void Start()
    {
        punchPoint = transform.Find("PunchPoint").localPosition;  //PunchObjを出す位置を取得
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = this.transform.position;  //プレイヤーの現在の位置を取得
       
        //移動
        if (Input.GetKey(KeyCode.A)) //左
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D)) //右
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (playerPos.y <= 0.5 && Input.GetKey(KeyCode.Space))  //ジャンプ
        {
            transform.Translate(0, jumpSpeed * Time.deltaTime, 0);
            Debug.Log("Space");
        }

        //攻撃（パンチ）
        if (Input.GetKeyUp(KeyCode.Return))
        {
            //PunchObjを生成
            Instantiate(PunchObj, transform.position + punchPoint, Quaternion.identity);
            Debug.Log("Return");
        }
        //防御
        //道具
    }

}
