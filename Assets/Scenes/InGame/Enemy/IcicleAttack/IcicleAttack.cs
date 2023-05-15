using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour //�N���X������
{
    public AttackSettings icicleAttackSettings;


    public void IcicleAttack()
    {

        icicleAttackSettings.timer += Time.deltaTime;

        if (icicleAttackSettings.timer >= icicleAttackSettings.spawnInterval)
        {
            icicleAttackSettings.timer = 0f;

            // ��ʊO�ɃI�u�W�F�N�g�𐶐�����
            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), 7f, 0f);//Random.Range(-10f, 10f), 7f, 0f
            GameObject obj = Instantiate(icicleAttackSettings.prefab, spawnPos, Quaternion.identity);

            obj.transform.DOMoveY(
                -30f, //�ړ���
                icicleAttackSettings.life // ���o����
            ).OnComplete(() =>
            {

                Destroy(obj);
            });
        }
    }
}