using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings WatergunSettings;
    public AudioClip soundClip; // �����t�@�C��
    private bool hasExecuted = false;

    public void WaterGunAttack()
    {
        if (!hasExecuted)
        {
            hasExecuted = true;

            // �����_���ȕ��������肷��
            bool moveRight = Random.value < 0.5f; // 50%�̊m���ŉE�����Ɉړ�����

            // �v���C���[��y���W���擾����
            float playerY = GameObject.FindGameObjectWithTag("Player").transform.position.y + 0.5f;

            // ��ʍ��[�܂��͉E�[�ɃI�u�W�F�N�g�𐶐�����
            float spawnX = moveRight ? -12f : 12f;
            Vector3 spawnPos = new Vector3(spawnX, playerY, 0f);

            // �ړ��ʂƖڕW�ʒu��ݒ肷��
            float moveAmount = moveRight ? 40f : -40f; // �E���琶�����ꂽ�ꍇ��-40f�A�����琶�����ꂽ�ꍇ��40f
            Vector3 targetPos = new Vector3(spawnPos.x + moveAmount, spawnPos.y, spawnPos.z);

            GameObject obj = Instantiate(WatergunSettings.prefab, spawnPos, Quaternion.identity);

            // AudioSource�R���|�[�l���g��ǉ����ĉ����Đ�����
            AudioSource audioSource = obj.AddComponent<AudioSource>();
            audioSource.clip = soundClip;
            audioSource.Play();

            obj.transform.DOMove(
                targetPos, // �ڕW�ʒu
                WatergunSettings.life // ���o����
            ).OnComplete(() =>
            {
                Destroy(obj);
                hasExecuted = false; // �ēx���s���邽�߂Ƀt���O�����Z�b�g
            });
        }
    }
}
