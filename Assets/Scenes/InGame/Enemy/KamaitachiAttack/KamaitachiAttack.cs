using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyAttack : MonoBehaviour
{
    [System.Serializable]
    public struct KamaitachiAttackSettings
    {
        public GameObject kamaitachiSpawnPos;
        public GameObject kamaitachiComing;
    }
    public KamaitachiAttackSettings kamaitachiAttackSettings;

    private float timer;
    private bool attackFlag = false;  //��񂾂����������p
    private GameObject plyerObj;
    private Vector3 playerPos;
    private Vector3 KSpawnPos;
    private Vector3 KCSpawnPos;

    //����������
    public void KamaitachiAttackInitialize()
    {
        timer = 0f;  //�^�C�}�[������
        attackFlag = true;  //��񂾂����������悤��true��

        //�v���C���[�̈ʒu���擾
        plyerObj = GameObject.FindWithTag("Player");
        playerPos = plyerObj.transform.position;

    }

    //�U���̊֐�
    public void KamaitachiAttack()
    {
        if (attackFlag)
        {
            KamaitachiSpawnPosSpawn();
            KamaitachiComingSpawn();
        }

        attackFlag = false;
    }

    void KamaitachiSpawnPosSpawn()
    {
        KSpawnPos = new Vector3(playerPos.x, 12f, 0f);  //��������ʒu

        //�I�u�W�F�N�g����
        GameObject KSP = Instantiate(kamaitachiAttackSettings.kamaitachiSpawnPos, KSpawnPos, Quaternion.identity);
    }

    void KamaitachiComingSpawn()
    {
        KCSpawnPos = new Vector3(playerPos.x, 4f, 0f);  //��������ʒu
        //�I�u�W�F�N�g����
        GameObject KC = Instantiate(kamaitachiAttackSettings.kamaitachiComing, KCSpawnPos, Quaternion.identity);
    }
}
