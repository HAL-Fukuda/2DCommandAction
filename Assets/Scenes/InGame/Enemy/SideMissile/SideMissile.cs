using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Net.Sockets;

public class SideMissile : MonoBehaviour
{
    public enum eDirection
    {
        left,
        right
    }
    public eDirection direction; // ���˕���
    public float speed;
    public float lifeTime;

    public GameObject explosionPrefab; // �����G�t�F�N�g�̃v���n�u
    public AudioClip windSE;
    public AudioClip spawnSE;

    private SpriteRenderer spriteRenderer;
    private Tweener tweener;
    private float timer;
    private bool isFired;

    // Start is called before the first frame update
    void Start()
    {
        // SE�Đ�
        AudioSource.PlayClipAtPoint(spawnSE, transform.position);

        // ���˕����ɍ��킹�ĉ�]
        Vector3 rot = Vector3.zero;
        if (direction == eDirection.left)
        {
            rot.z = 180;
        }
        transform.rotation = Quaternion.Euler(rot);

        // �������ꂽ��^�C�}�[���Z�b�g
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= 0.5f)
        {
            if (isFired == false) // ���˂������ǂ���
            {
                isFired = true;
                Fire();
            }
        }

        if (timer >= lifeTime)
        {
            // �������Ԃ��؂��Ɣ���
            Explosion();
        }

        // �����ɂԂ���Ɣ���
    }

    // ����
    void Fire()
    {
        // SE�Đ�
        AudioSource.PlayClipAtPoint(windSE, transform.position);
        // �g�����X�t�H�[�����擾
        Transform objectTransform = this.transform;
        // ���[�J��X���Ɍ������Ĉړ�
        tweener = this.transform.DOLocalMove(objectTransform.right * 50f, speed).SetRelative(true);
    }

    void Explosion()
    {
        // tween�������I��������
        if (tweener != null)
        {
            tweener.Kill();
        }

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

    // 1�b��ɃI�u�W�F�N�g���폜����֐�
    void DestroyObject()
    {
        Destroy(this.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        // �����ɂԂ������甚��
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Command") || other.gameObject.CompareTag("Platform"))
        {
            Explosion();
        }
    }
}