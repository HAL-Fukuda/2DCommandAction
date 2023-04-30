using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private GameObject player;
    private GameObject lifeMgr;
    public float lifeTimer = 3.0f; // 生存時間

    void Start()
    {
        player = GameObject.Find("Player");
        lifeMgr = GameObject.Find("Life");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayerPosition();

        // タイマーを減らす
        lifeTimer -= Time.deltaTime;

        // 生存時間が０になったら削除
        if(lifeTimer < 0)
        {
            lifeMgr.GetComponent<LifeManager>().InvincibilityOff();    // 無敵off
            Destroy(this.gameObject);
        }
    }

    // プレイヤーの座標に追従する
    private void FollowPlayerPosition()
    {
        Vector3 pos = player.transform.position;
        pos += new Vector3(0, 1, 0);
        this.transform.position = pos;
    }
}
