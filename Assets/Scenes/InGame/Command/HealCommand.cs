using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    [SerializeField] private ParticleSystem healEffect;  //ヒールのPrefab
    [SerializeField] private GameObject healSE;          //ヒールのSE
    [SerializeField] private GameObject PlayerObj;          //プレイヤーの位置
    [SerializeField] private int healVal;                   //回復量

    private ParticleSystem _healInstance;
    private GameObject _healSEInstance;

    public GameObject life;
    

    void HealCommandInitialize()
    {
        
    }

    void HealCommandUpdate()
    {

    }

    public void HealEffectPlay()
    {
        //エフェクトのインスタンスを生成
        _healInstance = Instantiate(healEffect);
        //エフェクトの発生位置をプレイヤーの位置にする
        _healInstance.transform.position = PlayerObj.transform.position;

        HealSoundPlay();

        //PlayerのHPを回復する処理
        life.GetComponent<LifeManager>().GetHeal(healVal);
        //メッセージを表示する処理
    }

    public void HealSoundPlay()
    {
        _healSEInstance = Instantiate(healSE);
        _healSEInstance.transform.position = PlayerObj.transform.position;
    }
}
