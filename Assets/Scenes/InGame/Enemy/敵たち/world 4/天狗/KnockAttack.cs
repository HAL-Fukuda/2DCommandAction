using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings KnockAttackSettings;
    private Vector3 KAPosition;     // 攻撃発生位置
    private Rigidbody2D KArgd;

    private GameObject KAobj;

    private bool KAflg = true;

    void GetPlayerPositionToKA()
    {
        GameObject PlayerObject = GameObject.Find("Player");

        KAPosition = PlayerObject.transform.position;
        KAPosition.y = 6.0f;
        KAPosition.z = 0.0f;
    }

    void KAobjDestroy()
    {
        Destroy(KAobj);
    }

    void KAflgTrue()
    {
        KAflg = true;
    }

    void KAobjBeating()
    {
        KArgd.AddForce(new Vector3(0.0f, -1.0f, 0.0f) * 1000.0f);  // 下方向に力をかける
    }

    public void KnockAttack()
    {
        if (KAflg)
        {
            KnockAttackSettings.timer = 0f;

            GetPlayerPositionToKA();

            spawnPos = new Vector3(KAPosition.x, KAPosition.y, 0.0f);
            KAobj = Instantiate(KnockAttackSettings.prefab, spawnPos, Quaternion.identity);
            KArgd = KAobj.GetComponent<Rigidbody2D>();

            KAobj.transform.DOPath(
            path: new Vector3[] { new Vector3(KAPosition.x + 2, KAPosition.y + 0.3f, 0),
                                 new Vector3(KAPosition.x + 2, KAPosition.y - 0.3f, 0),
                                 new Vector3(KAPosition.x - 2, KAPosition.y + 0.3f, 0),
                                 new Vector3(KAPosition.x - 2, KAPosition.y - 0.3f, 0),
                                 new Vector3(KAPosition.x, KAPosition.y, 0)}, //移動するポイント
            duration: 3f, //移動時間
            pathType: PathType.CatmullRom //移動するパスの種類
            ).OnComplete(KAobjBeating);


            Invoke("KAobjDestroy", 3.5f);   // 数秒後にオブジェクトを消す

            KAflg = false;
            Invoke("KAflgTrue", KnockAttackSettings.spawnInterval);
        }
    }
}
