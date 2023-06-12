using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAbsorbEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem slashEffectPrefab;
    [SerializeField] private GameObject slashSEPrefab;

    private Transform target;
    private GameObject enemy;
    private ParticleSystem _slashEffectInstance;
    private GameObject _slashSEInstance;
    private Vector3 targetPos;

    public float speed = 5.0f;
    public string attackMessage = "";

    bool isFinished = false;

    void Start()
    {
        target = GameObject.FindWithTag("Enemy").transform;
        targetPos = target.transform.position;
    }

    void FixedUpdate()
    {
        if (!isFinished)
        {
            Vector3 absorbPos = this.transform.position;

            AbsorbMove();
            if (targetPos == absorbPos)
            {
                SlashEffectPlay();
                SlashSEPlay();

                isFinished = true;

                //Enemy�Ƀ_���[�W��^����
                enemy.GetComponent<Enemy>().GetBigDamage();
                //���b�Z�[�W��\��
                MessageWindow.Instance.SetDebugMessage(attackMessage);

                // �����ɂ���
                ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>();
                particleSystem.Stop();
            }
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

    public bool IsFinished()
    {
        return isFinished;
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
