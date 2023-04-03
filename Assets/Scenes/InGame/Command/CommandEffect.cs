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

    public int commandHP;  //コマンドのHP
   
    void CommandEffectInitialize()
    {
        rb2d = this.GetComponent<Rigidbody2D>();  //衝突時にオブジェクトを消す際に使用
    }
    
    void CommandEffectUpdate()
    {
       
    }

    ////Playerタグが付いたオブジェクトが一定回数当たったらコマンドを消す
    //private void CommandEffectOnCollisionEnter(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Debug.Log("HIT");
    //        commandHP -= 1;  //コマンドのHP減少
    //        Debug.Log(commandHP);

    //        if (commandHP <= 0)
    //        {
    //            EffectPlay();  //Effect再生
    //            Destroy(gameObject);  //コマンドを削除
    //        }

    //    }
    //}

    //コマンドにHPを持たせる
    public void CommandHit()  
    {
        commandHP -= 1;  //コマンドのHP減少
        //Debug.Log(commandHP);

        if (commandHP <= 0)
        {
            // GameMgrにコマンドを渡す
            GameMgr.Instance.StoreCommand(gameObject);

            EffectPlay();   //Effect再生
            SoundPlay();    //SE再生
            gameObject.SetActive(false);  //コマンドを削除
        }
    }

    //エフェクト再生
    void EffectPlay()  
    {
        //ParticleSystemのインスタンスを生成
        _effectInstance = Instantiate(EffectPrefab);
        //Effectの発生位置をコマンドの位置にする
        _effectInstance.transform.position = this.transform.position;
        //Effectを再生
        _effectInstance.Play();
    }

    //SE再生
    void SoundPlay()  
    {
        //Soundのインスタンスを生成
        _soundInstance = Instantiate(SoundPrefab);
        //Soundの発生位置をコマンドの位置にする
        _soundInstance.transform.position = this.transform.position;
        //Soundは発生と同時に鳴るようにしている
    }
}
