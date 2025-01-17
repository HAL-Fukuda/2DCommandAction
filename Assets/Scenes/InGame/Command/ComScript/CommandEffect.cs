using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] private ParticleSystem EffectPrefab;  //EffectのPrefabを設定
    [SerializeField] private GameObject     SoundPrefab;   //SoundのPrefabを設定
    [SerializeField] private ParticleSystem hitEffectPrefab;
    [SerializeField] private GameObject     hitSEPrefab;

    private ParticleSystem _effectInstance;
    private GameObject _soundInstance;
    private ParticleSystem _hitEffectInstance;
    private GameObject _hitSEInstance;

    Renderer objectRenderer;
    private int currentHealth;  //現在のHP
    public Material materialCom;  //変更するマテリアルPrefab
    public Material materialBigCom;  //変更するマテリアルPrefabデカコマンド用

    public int commandHP;  //コマンドのHP

    void Start()
    {
        currentHealth = commandHP;
        objectRenderer = GetComponent<Renderer>();
    }
   
    void CommandEffectInitialize()
    {
        rb2d = this.GetComponent<Rigidbody2D>();  //衝突時にオブジェクトを消す際に使用
    }
    
    void CommandEffectUpdate()
    {
       
    }

    //コマンドにHPを持たせる
    public void CommandHit()  
    {
        commandHP -= 1;  //コマンドのHP減少

        HitEffectPlay();
        ChangeMaterial();
        HitSEPlay();

        if (commandHP <= 0)
        {
            EffectPlay();   //Effect再生
            SoundPlay();    //SE再生

            //this.gameObject.SetActive(false);

            GameMgr.Instance.SetCommand(this.gameObject);

            // 透明にする
            MeshRenderer meshRenderer = this.GetComponent<MeshRenderer>();
            meshRenderer.enabled = false;

            // 当たり判定を消す
            BoxCollider2D boxCollider = this.GetComponent<BoxCollider2D>();
            boxCollider.enabled = false;

        }
    }

    //コマンドが壊れた時のエフェクト再生
    void EffectPlay()  
    {
        //ParticleSystemのインスタンスを生成
        _effectInstance = Instantiate(EffectPrefab);
        //Effectの発生位置をコマンドの位置にする
        _effectInstance.transform.position = this.transform.position;
        //Effectを再生
        _effectInstance.Play();
    }

    //コマンドに攻撃したときのエフェクトを再生
    void HitEffectPlay()
    {
        _hitEffectInstance = Instantiate(hitEffectPrefab);
        _hitEffectInstance.transform.position = this.transform.position;
        _hitEffectInstance.Play();
    }

    //コマンドが壊れた時のSE再生
    void SoundPlay()  
    {
        //Soundのインスタンスを生成
        _soundInstance = Instantiate(SoundPrefab);
        //Soundの発生位置をコマンドの位置にする
        _soundInstance.transform.position = this.transform.position;
        //Soundは発生と同時に鳴るようにしている
    }

    //コマンドに攻撃した時のSE再生
    void HitSEPlay()
    {
        _hitSEInstance = Instantiate(hitSEPrefab);
        _hitSEInstance.transform.position = this.transform.position;
    }
    
    //コマンドのマテリアルを変更する
    void ChangeMaterial()
    {
        currentHealth = commandHP;

        if (currentHealth == 1)
        {
            objectRenderer.material = materialCom;
        }
        if (currentHealth == 2)
        {
            objectRenderer.material = materialBigCom;
        }
    }
}
