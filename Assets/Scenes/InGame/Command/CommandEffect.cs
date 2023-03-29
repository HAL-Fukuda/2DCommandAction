using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandEffect : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] private ParticleSystem EffectPrefab;  //Effect��Prefab��ݒ�
    [SerializeField] private GameObject     SoundPrefab;   //Sound��Prefab��ݒ�

    private ParticleSystem _effectInstance;
    private GameObject _soundInstance;
   
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();  //�Փˎ��ɃI�u�W�F�N�g�������ۂɎg�p
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

            //�R�}���h���폜
           // Destroy(gameObject);
        }
    }

    void EffectPlay()
    {
        //ParticleSystem�̃C���X�^���X�𐶐�
        _effectInstance = Instantiate(EffectPrefab);
        //Effect�̔����ʒu���R�}���h�̈ʒu�ɂ���
        _effectInstance.transform.position = this.transform.position;
        //Effect���Đ�
        _effectInstance.Play();

        //SE���Đ�
        SoundPlay();
    }

    void SoundPlay()
    {
        //Sound�̃C���X�^���X�𐶐�
        _soundInstance = Instantiate(SoundPrefab);
        //Sound�̔����ʒu���R�}���h�̈ʒu�ɂ���
        _soundInstance.transform.position = this.transform.position;
        //Sound�͔����Ɠ����ɖ�悤�ɂ��Ă���
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

    //        EffectPlay();  //Effect�Đ�
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
    //        //�Ԃ������ʒu��Effect��prefab��z�u����
    //        Instantiate(EffectPrefab, this.transform.position, Quaternion.identity);
    //        _effectInstance.Play();
    //        Debug.Log("EffectPlay");
    //        //Destroy(gameObject);  //�I�u�W�F�N�g�j��
    //    }
    //}
}
