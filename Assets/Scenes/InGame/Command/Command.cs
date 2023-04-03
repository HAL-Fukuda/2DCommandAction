using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    // �ϐ���`-------------------------


    // �R�}���h�̎��
    public enum eCommandType
    {
        ATTACK,
        DEFENCE,
        HEAL
    }

    public eCommandType commandType;

    public bool isActive = false; // �A�N�e�B�u���ǂ���


    // �֐���`-------------------------

    void CommandInitialize()
    {

    }

    public void CommandAction()
    {
        Activate(); // �A�N�e�B�u��Ԃɂ���

        // �R�}���h�ɉ���������
        switch (commandType)
        {
            case eCommandType.ATTACK:// �U���̏���    
                SlashEffectPlay();

                // �������I��������A�N�e�B�u��Ԃɂ���
                Deactivate();

                break;
            case eCommandType.DEFENCE:// �h��̏���    
                ShealdAction();

                // �������I��������A�N�e�B�u��Ԃɂ���
                Deactivate();
                break;
            case eCommandType.HEAL:// �񕜂̏���
                HealEffectPlay();

                // �������I��������A�N�e�B�u��Ԃɂ���
                Deactivate();
                break;
        }

    }

    // �A�N�e�B�u��Ԃ��擾����
    public bool IsActive()
    {
        return isActive;
    }

    // �A�N�e�B�u��Ԃɂ���
    public void Activate()
    {
        isActive = true;
    }

    // ��A�N�e�B�u��Ԃɂ���
    public void Deactivate()
    {
        isActive = false;
    }
}
