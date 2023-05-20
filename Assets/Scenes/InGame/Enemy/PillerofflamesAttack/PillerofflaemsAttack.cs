using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings pofflamesSettings;

    public void PofflamesAttack()
    {

        // ��ʊO�ɃI�u�W�F�N�g�𐶐�����ʒu��3�����ɌŒ肷��
        Vector3[] spawnPositions = new Vector3[]
        {
                new Vector3(-5f, -7f, 0f),   // �ʒu1
                new Vector3(0f, -7f, 0f),    // �ʒu2
                new Vector3(5f, -7f, 0f)     // �ʒu3
        };

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            Vector3 spawnPos = spawnPositions[i];
            GameObject obj = Instantiate(pofflamesSettings.prefab, spawnPos, Quaternion.identity);

            obj.transform.DOMoveY(
                30f, // �ړ���
                pofflamesSettings.life // ���o����
            ).OnComplete(() =>
            {
                Destroy(obj);
            });
        }

    }
}
