using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    [SerializeField] private ParticleSystem SlashingEffect;  //斬撃のPrefab
    [SerializeField] private GameObject SlashingSE;      //斬撃のSE

    private ParticleSystem _slashInstance;
    private GameObject _slashSEInstance;

    private GameObject enemy;

    public string attackMessage = "";

    void AttackCommandInitialize()
    {

    }

    void AttackCommandUpdate()
    {

    }

    public void AttackCommand()
    {
        // エネミーのオブジェクト取得
        enemy = GameObject.Find("Enemy");

        SlashEffectPlay();

        SlashSoundPlay();

        //Enemyにダメージを与える
        enemy.GetComponent<EnemyGetDamage>().GetDamage();

        //メッセージを表示
        MessageWindow.Instance.SetDebugMessage(attackMessage);
    }

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
}
