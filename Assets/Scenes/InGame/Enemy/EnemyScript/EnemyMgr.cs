using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//----------------------------------------------
// �G�l�~�[�̐����Ȃǂ̊Ǘ��͂��ׂĂ����ōs��
//----------------------------------------------

public class EnemyMgr : MonoBehaviour
{
    public GameObject dragon;
    public GameObject slime;
    public GameObject goblin;
    public GameObject zombie;
    public GameObject skelton;


    public bool isAction; // �s�������ǂ���

    void EnemyMgrInitialize()
    {

    }

    void EnemyMgrUpdate()
    {

    }

    public void Action()
    {
        isAction = true;

        // �U���J�n

        // �U������

        // �U���I��

        isAction = false;
    }
}
