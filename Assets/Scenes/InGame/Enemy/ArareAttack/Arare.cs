using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arare : MonoBehaviour
{
    private GameObject playerObj;
    private Transform target;
    private ParticleSystem particle;
    private LifeManager lifeManager;
    private bool onceHit;
    private float timer;
    

    void Start()
    {
        //SE�Đ�
        //�v���C���[�̈ʒu���擾
        playerObj = GameObject.FindWithTag("Player");
        target = playerObj.transform;
        //�p�[�e�B�N���V�X�e�����擾(�Đ����I����������肷��p�j
        particle = GetComponent<ParticleSystem>();
        //���C�t�}�l�[�W���[�X�N���v�g���擾
        GameObject LifeManagerObj = GameObject.Find("Life");
        lifeManager = LifeManagerObj.GetComponent<LifeManager>();
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        //������2.0�b�܂Ń^�[�Q�b�g�̕����ɍ��킹��
        if (timer <= 2.0f)
        {
            ForcusTarget();
        }

        //�Đ����I�������폜
        if (particle.isStopped)
        {
            Destroy(this.gameObject);
        }
    }

    // �^�[�Q�b�g�̕���������
    void ForcusTarget()
    {
        // �^�[�Q�b�g�̈ʒu���玩�����g�̃I�u�W�F�N�g�̈ʒu�������āA�����x�N�g�������߂�B
        Vector3 direction = target.position - this.transform.position;

        // �����x�N�g�����g���āA��]�p�x�����߂�B
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ��]�p�x���������g�̃I�u�W�F�N�g�ɓK�p����B
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (onceHit == false)
            {
                lifeManager.GetDamage(1);
                onceHit = true;
            }
        }
    }

    void ParticlePlay()
    {
        if (particle)
        {
            particle.Play();
        }
    }
}
