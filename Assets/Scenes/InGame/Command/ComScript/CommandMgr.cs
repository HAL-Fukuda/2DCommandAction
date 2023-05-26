using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CommandMgr : MonoBehaviour
{
    // �R���X�g���N�^�� private �ɂ��邱�ƂŁA�N���X�̊O������̃C���X�^���X������h���i�V���O���g���p�^�[���j
    private CommandMgr() { }

    // ���̃N���X�̃C���X�^���X�i���X�N���v�g����Q�Ƃ���Ƃ��͂��̃C���X�^���X����čs���j
    public static CommandMgr instance = null;

    public static CommandMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CommandMgr>(); // ���̏����d�������B
            }
            return instance;
        }
    }

    // �ϐ���`-------------------------

    // �֐���`-------------------------
    
    // �U�������������Ƃ��̃R�}���h�I������
    public void AttackHit(GameObject selectedCommand)
    {
        selectedCommand.GetComponent<Command>().CommandHit();
    }
}

