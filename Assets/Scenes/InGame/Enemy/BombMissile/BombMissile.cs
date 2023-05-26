using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BombMissile : MonoBehaviour
{
    private Transform target;
    private float timer;
    private bool isFired;
    private SpriteRenderer spriteRenderer;
    private bool oneceHit; // �P�x����������Ȃ��悤��
    public AudioClip windSE;
    public AudioClip spawnSE;
    public GameObject explosionPrefab; // �����G�t�F�N�g�̃v���n�u
    private Tweener tweener;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        // SE�Đ�
        AudioSource.PlayClipAtPoint(spawnSE, transform.position);

        // �v���C���[���^�[�Q�b�g�ɂ���
        GameObject player = GameObject.Find("Player");
        target = player.transform;

        // �������ꂽ��^�C�}�[���Z�b�g
        timer = 0.0f;

        //spriteRenderer = this.GetComponent<SpriteRenderer>();

        ForcusTarget();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>= 0.5f)
        {
            if (isFired == false) // ���˂������ǂ���
            {
                isFired = true;
                Fire();
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

    // ����
    void Fire()
    {
        // SE�Đ�
        AudioSource.PlayClipAtPoint(windSE, transform.position);
        // �g�����X�t�H�[�����擾
        Transform objectTransform = this.transform;
        // ���[�J��X���Ɍ������ĂP�b��10f�ړ�
        tweener = this.transform.DOLocalMove(objectTransform.right * 10f, speed).SetRelative(true).OnComplete(() =>
        {
            // �ړ����1�b��Material�̃A���t�@��0�ɂ���
            tweener = spriteRenderer.material.DOFade(0.0f, 1.0f).OnComplete(() =>
            {
                // �����ɂȂ�����폜
                Destroy(this.gameObject);
            });
        });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (oneceHit == false)
        {
            oneceHit = true;

            // �����ɂԂ������甚��
            if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Command") || other.gameObject.CompareTag("Platform"))
            {
                // tween�������I��������
                tweener.Kill();

                // �����G�t�F�N�g����
                Instantiate(explosionPrefab, this.transform);

                // �~�T�C���𓧖��ɂ���
                spriteRenderer = this.GetComponent<SpriteRenderer>();
                Color spriteColor = spriteRenderer.color;
                spriteColor.a = 0f; // �A���t�@�l��0�ɐݒ�i���S�ɓ����j
                spriteRenderer.color = spriteColor;

                // �I�u�W�F�N�g���폜����
                Invoke("DestroyObject", 0.2f);
            }
        }
    }

    // 1�b��ɃI�u�W�F�N�g���폜����֐�
    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}