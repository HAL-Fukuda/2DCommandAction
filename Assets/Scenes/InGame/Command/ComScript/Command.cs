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
    
    public bool isActive = false; // ���s�����ǂ���
    private bool oneceFlag = false;


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

                if (oneceFlag == false)
                {
                    oneceFlag = true;
                    AttackCommand();
                }

                if (_attackEffectInstance.GetComponent<AbsorbEffect>().IsFinished())
                {
                    // �������I��������A�N�e�B�u��Ԃɂ���
                    Deactivate();
                    // �G�t�F�N�g�I�u�W�F�N�g���폜
                    _attackEffectInstance.GetComponent<AbsorbEffect>().DestroyObject();
                }

                break;
            case eCommandType.DEFENCE:// �h��̏���    
                ShealdAction();

                // �������I��������A�N�e�B�u��Ԃɂ���
                Deactivate();
                break;
            case eCommandType.HEAL:// �񕜂̏���
                HealCommand();

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
