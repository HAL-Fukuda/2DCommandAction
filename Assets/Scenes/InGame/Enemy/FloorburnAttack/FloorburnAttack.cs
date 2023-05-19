using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour //�N���X������
{
    public AttackSettings floorburnSettings;
    private GameObject FBobj;
    private bool FBflag=true;

    public void FloorburnAttack()
    {

        if (FBflag)
        {
            FBflag = false;
            //floorburnSettings.timer += Time.deltaTime;

            //if (floorburnSettings.timer >= floorburnSettings.spawnInterval)
            //{
                floorburnSettings.timer = 0f;

                // ��ʊO�ɃI�u�W�F�N�g�𐶐�����
                Vector3 spawnPos = new Vector3(0f, -3f, 0f);  //���X�|�[���ʒu
                FBobj = Instantiate(floorburnSettings.prefab, spawnPos, Quaternion.identity);

                FBobj.transform.DOMove(
                   new Vector3(0, -2.75f, 0), // �ړ��I���n�_
                    floorburnSettings.life // ���o����
                ).OnComplete(() =>
                {
                    Invoke("FBDestroy", 5f);   // ���b��ɃI�u�W�F�N�g������
            });
            //}

            Invoke("FBflagtrue", 5f);
        }
    }

    void FBDestroy()
    {
        Destroy(FBobj);
    }

    void FBflagtrue()
    {
        FBflag = true;
        Debug.Log("������[");
    }
}
