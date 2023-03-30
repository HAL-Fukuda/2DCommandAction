using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] private ParticleSystem EffectPrefab;  //EffectのPrefabを設定
    [SerializeField] private GameObject     SoundPrefab;   //SoundのPrefabを設定

    private ParticleSystem _effectInstance;
    private GameObject _soundInstance;
   
    void CommandEffectInitialize()
    {
        rb2d = this.GetComponent<Rigidbody2D>();  //衝突時にオブジェクトを消す際に使用
    }
    
    void CommandEffectUpdate()
    {
       
    }

    private void CommandEffectOnCollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("HIT");

            EffectPlay();

            //コマンドを削除
           // Destroy(gameObject);
        }
    }

    void EffectPlay()
    {
        //ParticleSystemのインスタンスを生成
        _effectInstance = Instantiate(EffectPrefab);
        //Effectの発生位置をコマンドの位置にする
        _effectInstance.transform.position = this.transform.position;
        //Effectを再生
        _effectInstance.Play();

        //SEを再生
        SoundPlay();
    }

    void SoundPlay()
    {
        //Soundのインスタンスを生成
        _soundInstance = Instantiate(SoundPrefab);
        //Soundの発生位置をコマンドの位置にする
        _soundInstance.transform.position = this.transform.position;
        //Soundは発生と同時に鳴るようにしている
    }
}
