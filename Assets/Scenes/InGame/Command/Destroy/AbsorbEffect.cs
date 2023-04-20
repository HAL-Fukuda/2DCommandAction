using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem slashEffectPrefab;
    [SerializeField] private GameObject slashSEPrefab;

    private Transform target;
    private GameObject enemy;
    private ParticleSystem _slashEffectInstance;
    private GameObject _slashSEInstance;

    public float speed = 5.0f;
    public string attackMessage = "";

    void Start()
    {
        target = GameObject.FindWithTag("Enemy").transform;
    }

    void FixedUpdate()
    {
        Vector3 targetPos = target.transform.position;
        Vector3 absorbPos = this.transform.position;

        AbsorbMove();

        if (targetPos == absorbPos)
        {
            Destroy(this.gameObject);
            SlashEffectPlay();
            SlashSEPlay();

            //Enemyにダメージを与える
            enemy.GetComponent<Enemy>().GetDamage();
            //メッセージを表示
            MessageWindow.Instance.SetDebugMessage(attackMessage);
        }
    }

    void AbsorbMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }


    void SlashEffectPlay()
    {
        enemy = GameObject.FindWithTag("Enemy");
        _slashEffectInstance = Instantiate(slashEffectPrefab);
        _slashEffectInstance.transform.position = enemy.transform.position;
    }

    void SlashSEPlay()
    {
        enemy = GameObject.FindWithTag("Enemy");
        _slashSEInstance = Instantiate(slashSEPrefab);
        _slashSEInstance.transform.position = enemy.transform.position;
    }
}
