using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LaserPoint : MonoBehaviour
{
    private Transform target;
    private float timer;

    [SerializeField] Laser laser;

    public AudioClip chargeSE;

    void Start()
    {
        // SE�Đ�
        AudioSource.PlayClipAtPoint(chargeSE, transform.position);
        Debug.Log("�`���[�W�J�n");

        //���[�U�[���I�t�ɂ���
        laser.ObjectOff();

        //�������ꂽ��^�C�}�[���O�ɂ���
        timer = 0.0f;

        // �v���C���[���^�[�Q�b�g�ɂ���
        GameObject player = GameObject.Find("Player");
        target = player.transform;
    }

    void Update()
    {
        //�^�C�}�[�X�V
        timer += Time.deltaTime;

        //�^�[�Q�b�g�̕����ɍ��킹��
        if (timer <= 2.0f)
        {
            ForcusTarget();
        }

        //����
        if (timer >= 3.0f)
        {
            Fire();
        }

        //�폜
        if(timer >= 5.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void ForcusTarget()
    {
        // �^�[�Q�b�g�̈ʒu���玩�����g�̃I�u�W�F�N�g�̈ʒu�������āA�����x�N�g�������߂�B
        Vector3 direction = target.position - this.transform.position;

        // �����x�N�g�����g���āA��]�p�x�����߂�B
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ��]�p�x���������g�̃I�u�W�F�N�g�ɓK�p����B
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Fire()
    {
        laser.ObjectOn();
    }
}

