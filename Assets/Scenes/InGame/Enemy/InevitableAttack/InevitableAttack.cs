using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings InevitableAttackSettings;
    public AttackSettings OmenAttackSettings;

    // オブジェクトの位置を取得する
    private Vector3 IAPosition;

    public GameObject EnemyIA;

    private GameObject IAobj;
    private GameObject IAOobj;

    private Material IAmaterial;

    private bool IAflg = true;


    void GetPositionToIA()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform myObjectTransform = EnemySS.GetComponent<Transform>();

        // 後で"敵の名前(Clone)"に変える
        GameObject EnemyObject = GameObject.FindWithTag("Enemy");

        if (EnemyObject == null)
        {
            EnemyObject = GameObject.Find("Enemy2");
        }

        IAPosition = EnemyObject.transform.position;

        IAPosition.z = 0.0f;
        //Debug.Log(IAPosition);
    }

    void IAflgTrue()
    {
        IAflg = true;
    }

    void OmenIA()
    {
        spawnPos = new Vector3(IAPosition.x, IAPosition.y, 0.0f);
        IAOobj = Instantiate(OmenAttackSettings.prefab, spawnPos, Quaternion.identity);
        IAOobj.transform.DOScale(new Vector3(0.0f, 0.0f, 0.0f), 2.0f)
            .OnComplete(() =>
            {
                Destroy(IAOobj);
                Inevitable();
            });
    }

    void Inevitable()
    {
        spawnPos = new Vector3(IAPosition.x, IAPosition.y, 0.0f);
        IAobj = Instantiate(InevitableAttackSettings.prefab, spawnPos, Quaternion.identity);

        // GameObjectから最初のRendererを取得する
        Renderer renderer = IAobj.GetComponent<Renderer>();

        // Rendererが存在する場合、そのMaterialを取得する
        if (renderer != null)
        {
            IAmaterial = renderer.material;
            // 取得したMaterialを使って何らかの処理を行う
        }

        IAobj.transform.DOScale(new Vector3(30.0f, 30.0f, 1.0f), 2.0f)
            .OnComplete(InvisibleIA);
    }

    void InvisibleIA()
    {
        // 透明度を下げた後にオブジェクトを消す
        IAmaterial.DOFade(0f, 1f)
            .OnComplete(() =>
            {
                Destroy(IAobj);

                Invoke("IAflgTrue", InevitableAttackSettings.spawnInterval);
            });
    }



    public void InevitableAttack()
    {
        if (IAflg)
        {
            IAflg = false;

            GetPositionToIA();

            OmenIA();
        }
    }

  
}
