using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandEffect : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] private ParticleSystem EffectPrefab;  //EffectのPrefabを設定
    [SerializeField] private GameObject     SoundPrefab;   //SoundのPrefabを設定

    private ParticleSystem _effectInstance;
    private GameObject _soundInstance;
   
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();  //衝突時にオブジェクトを消す際に使用
    }
    
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
    //private void Awake()
    //{
    //    _effectInstance = Instantiate(EffectPrefab, transform);
    //    Debug.Log(_effectInstance);
    //}

    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        Debug.Log("HIT");

    //        EffectPlay();  //Effect再生
    //        if (Input.GetKey(KeyCode.Return))
    //        {
    //            Debug.Log("Return");
    //        }
    //    }
    //}

    //void EffectPlay()
    //{
    //    if (_effectInstance)
    //    {
    //        //ぶつかった位置にEffectのprefabを配置する
    //        Instantiate(EffectPrefab, this.transform.position, Quaternion.identity);
    //        _effectInstance.Play();
    //        Debug.Log("EffectPlay");
    //        //Destroy(gameObject);  //オブジェクト破壊
    //    }
    //}
}
