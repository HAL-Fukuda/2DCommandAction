using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings snowballAttackSettings;

    public void SnowBallAttack()
    {
        snowballAttackSettings.timer += Time.deltaTime;

        if (snowballAttackSettings.timer >= snowballAttackSettings.spawnInterval)
        {
            snowballAttackSettings.timer = 0f;

            // ��ʍ��[�ɃI�u�W�F�N�g�𐶐�����
            Vector3 spawnPos = new Vector3(-10f, Random.Range(2.5f, 3.3f), 0f);
            GameObject obj = Instantiate(snowballAttackSettings.prefab, spawnPos, Quaternion.identity);

            obj.transform.DOMoveX(
                30f, //�ړ���
                snowballAttackSettings.life // ���o����
            ).OnComplete(() =>
            {
                Destroy(obj);
            });
        }
    }
}