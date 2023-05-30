using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Energybullet : MonoBehaviour
{
    private Transform target;
    public float speed;
    public float lifeTime;

    //public AudioClip MoveSE;
    public GameObject explosionPrefab;

    private float timer;
    private float MaxAngle = 15;
    private SpriteRenderer spriteRenderer;
    private bool oneceHit = false; // �P�x����������Ȃ��悤��
    private Tweener tweener;

    // Start is called before the first frame update
    void Start()
    {
        //SE�Đ�
        //AudioSource.PlayClipAtPoint(MoveSE, transform.position);

        // �v���C���[���^�[�Q�b�g�ɂ���
        GameObject player = GameObject.Find("Player");
        target = player.transform;

        // �^�[�Q�b�g�̕���������
        ForcusTarget();

        // �������ꂽ��^�C�}�[���Z�b�g
        timer = 0.0f;

        // �X�v���C�g�����_���[�擾
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // 0.5f�b�o������z�[�~���O�J�n
        if (timer >= 3.0f)
        {
            HomingUpdate();
        }

        // �������Ԃ𒴂����甚��
        if (timer >= lifeTime)
        {
            if (oneceHit == false)
            {
                oneceHit = true;
                Explosion();
            }
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

    void HomingUpdate()
    {
        // �^�[�Q�b�g�̈ʒu���玩�����g�̃I�u�W�F�N�g�̈ʒu�������āA�����x�N�g�������߂�B
        Vector3 direction = target.position - this.transform.position;

        // �����x�N�g�����g���āA��]�p�x�����߂�B
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // �ǔ����\����������ő��]�p�x�����傫���Ȃ�Ȃ��悤�ɂ���
        // ��������������������������

        // ��]�p�x���������g�̃I�u�W�F�N�g�ɓK�p����B
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        // �ړ�����
        this.transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (oneceHit == false)
        {
            // �����ɂԂ������甚��
            if (other.gameObject.CompareTag("Player"))
            {
                oneceHit = true;
                Explosion();
            }
        }
    }

    void Explosion()
    {
        // �����G�t�F�N�g����
        Instantiate(explosionPrefab, this.transform);

        // �~�T�C���𓧖��ɂ���
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = 0f; // �A���t�@�l��0�ɐݒ�i���S�ɓ����j
        spriteRenderer.color = spriteColor;

        // �����蔻�������
        CapsuleCollider2D capsuleCollider = GetComponent<CapsuleCollider2D>();
        capsuleCollider.enabled = false;

        // �I�u�W�F�N�g���폜����
        Invoke("DestroyObject", 1.5f);
    }

    // �I�u�W�F�N�g���폜����֐�
    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
