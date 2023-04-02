using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    [SerializeField] private ParticleSystem SlashingEffect;  //斬撃のPrefab
    [SerializeField] private GameObject SlashingSE;      //斬撃のSE
    [SerializeField] private GameObject TargetObj;       //敵の位置

    private ParticleSystem _slashInstance;
    private GameObject _slashSEInstance;
    public GameObject enemy;

    void AttackCommandInitialize()
    {

    }

    void AttackCommandUpdate()
    {

    }

    void SlashEffectPlay()
    {
        //エフェクトのインスタンスを生成
        _slashInstance = Instantiate(SlashingEffect);
        //エフェクトの発生位置を敵の位置にする
        _slashInstance.transform.position = TargetObj.transform.position;

        SlashSoundPlay();

        //Enemyにダメージを与える
        enemy.GetComponent<EnemyGetDamage>().GetDamage();
        //メッセージを表示
    }

    //斬撃のSEを再生
    void SlashSoundPlay()
    {
        _slashSEInstance = Instantiate(SlashingSE);
        _slashSEInstance.transform.position = TargetObj.transform.position;
    }
}
