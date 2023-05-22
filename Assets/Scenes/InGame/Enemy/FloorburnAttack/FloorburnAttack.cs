using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    public AttackSettings floorburnSettings;
    public AudioClip floorburnSound; // �����t�@�C��
    private GameObject FBobj;
    private bool FBflag = true;

    public void FloorburnAttack()
    {
        if (FBflag)
        {
            FBflag = false;
            floorburnSettings.timer = 0f;

            Vector3 spawnPos = new Vector3(0f, -3f, 0f); // ���X�|�[���ʒu
            FBobj = Instantiate(floorburnSettings.prefab, spawnPos, Quaternion.identity);

            FBobj.transform.DOMove(
                new Vector3(0, -2.75f, 0), // �ړ��I���n�_
                floorburnSettings.life // ���o����
            ).OnComplete(() =>
            {
                Invoke("FBDestroy", 5f); // ���b��ɃI�u�W�F�N�g������
            });

            AudioSource audioSource = FBobj.AddComponent<AudioSource>();
            audioSource.clip = floorburnSound;
            audioSource.Play();

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
