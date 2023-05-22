using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings wofwaterSettings;
    public AudioClip WOWsound; // �����t�@�C��
    private bool WOWflag = false;

    public void WofwaterAttack()
    {
        if (!WOWflag)
        {
            WOWflag = true;

            // ��ʊO�ɃI�u�W�F�N�g�𐶐�����ʒu��2�����ɌŒ肷��
            Vector3[] spawnPositions = new Vector3[]
            {
                new Vector3(-8f, -10f, 0f),   // �ʒu1
                new Vector3(8f, -10f, 0f)     // �ʒu2
            };

            for (int i = 0; i < spawnPositions.Length; i++)
            {
                Vector3 spawnPos = spawnPositions[i];
                GameObject obj = Instantiate(wofwaterSettings.prefab, spawnPos, Quaternion.identity);

                // AudioSource�R���|�[�l���g��ǉ����ĉ������Đ�����
                AudioSource audioSource = obj.AddComponent<AudioSource>();
                audioSource.clip = WOWsound;
                audioSource.Play();

                obj.transform.DOMoveY(
                    spawnPos.y + 11f, // �㏸�ڕW�ʒu
                    3f // �㏸����
                ).OnComplete(() =>
                {
                    StartCoroutine(StopAndDescend(obj, spawnPos, 10f)); // �㏸��̒�~�Ɖ��~�������J�n
                });
            }
        }
    }

    IEnumerator StopAndDescend(GameObject obj, Vector3 spawnPos, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        obj.transform.DOMoveY(
            spawnPos.y, // ���~�ڕW�ʒu�i�����ʒu�j
            3f // ���~����
        ).OnComplete(() =>
        {
            StartCoroutine(DelayedDestroy(obj, 3f)); // 3�b��ɃI�u�W�F�N�g������
        });

        // AudioSource�R���|�[�l���g���~���ĉ����Đ��𒆒f
        AudioSource audioSource = obj.GetComponent<AudioSource>();
        audioSource.Stop();

        // �ēx���s�ł���悤�Ƀt���O�����Z�b�g
        WOWflag = false;
    }

    IEnumerator DelayedDestroy(GameObject obj, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        Destroy(obj);
    }
}
