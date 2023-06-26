using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private GameObject player;
    private GameObject lifeMgr;
    public float lifeTimer = 3.0f; // 生存時間

    bool isEnemy = false;

    void Start()
    {
        player = GameObject.Find("Player");
        lifeMgr = GameObject.Find("Life");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayerPosition();

        // 敵のターンが終わったらシールドを無効にする
        if (GameMgr.Instance.battleState == GameMgr.eBattleState.ENEMY)
        {
            isEnemy = true;
        }
        if (isEnemy && GameMgr.Instance.battleState != GameMgr.eBattleState.ENEMY)
        {
            DestroyShield();
        }
    }

    // プレイヤーの座標に追従する
    private void FollowPlayerPosition()
    {
        Vector3 pos = player.transform.position;
        pos += new Vector3(0, 1, 0);
        this.transform.position = pos;
    }

    public void DestroyShield() // シールドを削除
    {
        lifeMgr.GetComponent<LifeManager>().InvincibilityOff();    // 無敵off
        Destroy(this.gameObject);
    }
}
