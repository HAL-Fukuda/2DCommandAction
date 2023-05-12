using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ---------------------------------------------------
// プレイヤーが当たるとLifeを-99する。
// コマンドが当たるとオブジェクトを削除する。
// ----------------------------------------------------
public class DeadZone : MonoBehaviour
{
    private GameObject lifeObject;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lifeObject = GameObject.Find("Life");
            lifeObject.GetComponent<LifeManager>().GetDamage(99);
        }
        
        if(collision.gameObject.tag == "Command")
        {
            // 1個降らす
            CommandMgr.Instance.DropAll(1);
            Destroy(collision.gameObject);
        }
    }
}
