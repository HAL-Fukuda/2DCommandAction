using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsMacineGun : MonoBehaviour
{
    private GameObject forcusPointObj;
    private Transform targetPos;

    private ParticleSystem particle;

    private AudioSource audio;
    public AudioClip bulletsSound;

    private GameObject lifeManagerObj;
    private LifeManager lifeManager;

    private float timer;

    void Start()
    {
        forcusPointObj = GameObject.FindWithTag("ForcusPoint");
        targetPos = forcusPointObj.transform;

        particle = GetComponent<ParticleSystem>();

        audio = GetComponent<AudioSource>();

        lifeManagerObj = GameObject.Find("Life");
        lifeManager = lifeManagerObj.GetComponent<LifeManager>();
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer <= 1f)
        {
            ForcusTarget();
        }

        audio.Play();

        if (particle.isStopped)
        {
            Destroy(this.gameObject);
        }
    }

    // �^�[�Q�b�g�̕���������
    void ForcusTarget()
    {
        // �^�[�Q�b�g�̈ʒu���玩�����g�̃I�u�W�F�N�g�̈ʒu�������āA�����x�N�g�������߂�B
        Vector3 direction = targetPos.position - this.transform.position;

        // �����x�N�g�����g���āA��]�p�x�����߂�B
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ��]�p�x���������g�̃I�u�W�F�N�g�ɓK�p����B
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
        }
    }
}
