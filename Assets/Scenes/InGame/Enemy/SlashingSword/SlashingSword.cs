using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings SlashingSwordSettings;
    private Vector3 SSPosition;

    public GameObject EnemySS;

    private GameObject SSobj;
    private bool SSflg = true;

    void GetPositionToSS()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        Transform myObjectTransform = EnemySS.GetComponent<Transform>();

        SSPosition = myObjectTransform.position;

        //SSPosition.x = 0.0f;
        //SSPosition.y = 3.5f;
        SSPosition.z = 0.0f;
        Debug.Log(SSPosition);
    }

    void SSobjDestroy()
    {
        Destroy(SSobj);
    }

    void SSflgTrue()
    {
        SSflg = true;
    }

    void Slashing()
    {
        SSobj.transform.DORotate(new Vector3(0, 0, -360), 1.5f, RotateMode.FastBeyond360)
            .SetEase(Ease.InOutBack)
            .OnComplete(SSobjDestroy);
    }

    public void SlashingSword()
    {
        if (SSflg)
        {
            SSflg = false;
            GetPositionToSS();

            spawnPos = new Vector3(SSPosition.x, SSPosition.y, 0.0f);
            SSobj = Instantiate(SlashingSwordSettings.prefab, spawnPos, Quaternion.identity);

            Invoke("Slashing", 0.3f);
            Invoke("SSflgTrue", SlashingSwordSettings.spawnInterval);
        }
    }




    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        SlashingSword();
    //    }
    //}
}
