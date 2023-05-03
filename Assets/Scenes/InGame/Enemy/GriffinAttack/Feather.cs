using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Feather : MonoBehaviour
{
    private Transform target;
    private float timer;
    private bool isFired;
    private Vector3 goalPosition; // ���B���W
    private SpriteRenderer spriteRenderer;
    private LifeManager lifeManager;
    private bool oneceHit; // �P�x����������Ȃ��悤��
    public AudioClip windSE;
    public AudioClip spawnSE;

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

        spriteRenderer = this.GetComponent<SpriteRenderer>();

        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManager�R���|�[�l���g���擾����
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // �^�C�}�[�X�V
        timer += Time.deltaTime;

        // ������2.0�b�܂Ń^�[�Q�b�g�̕����ɍ��킹��
        if (timer <= 2.0f)
        {
            ForcusTarget();
        }

        // ������3.5�b�o�����甭��
        if (timer >= 3.5f)
        {
            if(isFired == false) // ���˂������ǂ���
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

        // �^�[�Q�b�g�̍��W�𓞒B���W�Ƃ��Ď擾
        goalPosition = target.position;
    }

    // ����
    void Fire()
    {
        // SE�Đ�
        AudioSource.PlayClipAtPoint(windSE, transform.position);
        // ���B���W�Ɍ������ĂP�b�ňړ�
        this.transform.DOMove(goalPosition, 1.0f).OnComplete(() =>
        {
            // �ړ����1�b��Material�̃A���t�@��0�ɂ���
            spriteRenderer.material.DOFade(0.0f, 1.0f).OnComplete(() =>
            {
                // �����ɂȂ�����폜
                Destroy(this.gameObject);
            });
        });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (oneceHit == false)
            {
                lifeManager.GetDamage(1);
                oneceHit = true;
            }
        }
    }
}
