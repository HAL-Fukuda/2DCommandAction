using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    //[System.Serializable]
    //public struct AttackSettings
    //{
    //    public GameObject prefab;
    //    public float spawnInterval;
    //    public float life;
    //    [SerializeField][Header("いじらないで")] public float timer;

    //    public AttackSettings(GameObject prefab, float spawnInterval, float life)
    //    {
    //        this.prefab = prefab;
    //        this.spawnInterval = spawnInterval;
    //        this.life = life;
    //        this.timer = 0f;
    //    }
    //}

    // プレイヤーオブジェクトを参照する
    //public GameObject player1;  // プレイヤーの位置取得用

    public AttackSettings BeamComingAttackSettings;
    public AttackSettings SatelliteAttackSettings;

    // オブジェクトの位置を取得する
    private Vector3 objectPosition;
    private Vector3 spawnPos;

    private bool SBflg = true;

    void GetPlayerPositionX()
    {
        // ゲームオブジェクトのTransformコンポーネントを取得する
        //Transform myObjectTransform = player1.GetComponent<Transform>();

        GameObject PlayerObject = GameObject.Find("Player");

        objectPosition = PlayerObject.transform.position;

        Debug.Log("ポジション取得");
    }

    void premonition()
    {

        // プレイヤーの位置に予兆発生
        spawnPos = new Vector3(objectPosition.x, 0f, 0f);
        GameObject obj = Instantiate(BeamComingAttackSettings.prefab, spawnPos, Quaternion.identity);
        obj.transform.DOMoveY(
                0, //移動量
                2.5f // 演出時間
            ).OnComplete(() =>
            {
                Destroy(obj);
                RealBeam();
            });
    }

    void RealBeam()
    {
        // プレイヤーの位置にビーム発生
        //Vector3 spawnPos = new Vector3(objectPosition.x, 0f, 0f);
        GameObject obj1 = Instantiate(SatelliteAttackSettings.prefab, spawnPos, Quaternion.identity);
        obj1.transform.DOMoveY(
                0, //移動量
                2.5f // 演出時間
            ).OnComplete(() =>
            {
                Destroy(obj1);
            });
    }

    void SBflgTrue()
    {
        SBflg = true;
        Debug.Log("フラグがトゥルー");
    }

    public void SatelliteBeam()
    {
        if (SBflg)
        {
            GetPlayerPositionX();
            premonition();

            SBflg = false;
            Invoke("SBflgTrue", BeamComingAttackSettings.spawnInterval + SatelliteAttackSettings.spawnInterval);
        }
        //Debug.Log(objectPosition);
    }


    // Start is called before the first frame update


    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.B))
    //    {
    //        SatelliteBeam();
    //    }
    //}
}
