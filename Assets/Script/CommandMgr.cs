using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandMgr : MonoBehaviour
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

    // �S�̃R�}���h�̂��ꂼ���GameObject
    public GameObject command1;
    public GameObject command2;
    public GameObject command3;
    public GameObject command4;

    // �֐���`-------------------------

    // �U�������������Ƃ��̃R�}���h�I������
    public void AttackHit(GameObject selectedCommand)
    {
        // �I�����ꂽ�R�}���h���A�N�e�B�u�ɂ���
        selectedCommand.GetComponent<Command>().Activate();
        // GameMgr�ɑI�����ꂽ�R�}���h��n��
        GameMgr.Instance.SetCommand(selectedCommand);

        // ���̃R�}���h���A�N�e�B�u�ɂ���
        if (selectedCommand != command1)
        {
            command1.GetComponent<Command>().Deactivate();
        }
        if (selectedCommand != command2)
        {
            command2.GetComponent<Command>().Deactivate();
        }
        if (selectedCommand != command3)
        {
            command3.GetComponent<Command>().Deactivate();
        }
        if (selectedCommand != command4)
        {
            command4.GetComponent<Command>().Deactivate();
        }
    }

    // ���ׂẴR�}���h���A�N�e�B�u�ɂ���
    public void DeactivateALL()
    {
        command1.GetComponent<Command>().Deactivate();
        command2.GetComponent<Command>().Deactivate();
        command3.GetComponent<Command>().Deactivate();
        command4.GetComponent<Command>().Deactivate();
    }
}

