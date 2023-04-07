using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    [SerializeField] private ParticleSystem SlashingEffect;  //斬撃のPrefab
    [SerializeField] private GameObject SlashingSE;      //斬撃のSE
    [SerializeField] private ParticleSystem attackEffectPrefab;  //繋ぎのエフェクト
    [SerializeField] private GameObject attackSEPrefab;  //繋ぎのSE

    private ParticleSystem _slashInstance;
    private GameObject _slashSEInstance;
    private ParticleSystem _attackEffectInstance;
    private GameObject _attackSEInstance;

    private GameObject enemy;

    //public string attackMessage = "";

    void AttackCommandInitialize()
    {

    }

    void AttackCommandUpdate()
    {

    }

    public void AttackCommand()
    {
        AttackEffectPlay();
        //AttackSEPlay();

        //// エネミーのオブジェクト取得
        //enemy = GameObject.Find("Enemy");
        //SlashEffectPlay();
        //SlashSoundPlay();
        ////Enemyにダメージを与える
        //enemy.GetComponent<EnemyGetDamage>().GetDamage();
        ////メッセージを表示
        //MessageWindow.Instance.SetDebugMessage(attackMessage);
    }

    //斬撃のエフェクトを再生
    void SlashEffectPlay()
    {
        //エフェクトのインスタンスを生成
        _slashInstance = Instantiate(SlashingEffect);
        //エフェクトの発生位置を敵の位置にする
        _slashInstance.transform.position = enemy.transform.position;
    }

    //斬撃のSEを再生
    void SlashSoundPlay()
    {
        // エネミーのオブジェクト取得
        enemy = GameObject.Find("Enemy");

        _slashSEInstance = Instantiate(SlashingSE);
        _slashSEInstance.transform.position = enemy.transform.position;
    }

    //コマンドが壊れてから斬撃のエフェクトまでのエフェクトを再生
    void AttackEffectPlay()
    {
        _attackEffectInstance = Instantiate(attackEffectPrefab);
        _attackEffectInstance.transform.position = this.transform.position;
    }

    //コマンドが壊れてから斬撃のエフェクトまでのSEを再生
    void AttackSEPlay()
    {
        _attackSEInstance = Instantiate(attackSEPrefab);
        _attackSEInstance.transform.position = this.transform.position;
    }
}
