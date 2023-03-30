using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Command : MonoBehaviour
{
    // �ϐ���`-------------------------

    public Material materialStandard; // ��A�N�e�B�u���̃}�e���A��
    public Material materialActive; // �A�N�e�B�u���̃}�e���A��

    // �R�}���h�̎��
    public enum eCommandType
    {
        NONE,
        ATTACK,
        ITEM,
    }

    public eCommandType commandType;

    public bool isActive = false; // �A�N�e�B�u���ǂ���

    private MeshRenderer meshRenderer;

    // �֐���`-------------------------

    // Start is called before the first frame update
    void CommandInitialize()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void CommandUpdate()
    {

    }

    // �A�N�e�B�u��Ԃ��擾����
    public bool IsActive()
    {
        return isActive;
    }

    // �Փˎ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �^�O��Punch���ǂ���
        if (collision.gameObject.CompareTag("Punch"))
        {
            // �R�}���h�ɍU���������������̏������Ăяo��
            CommandMgr.Instance.AttackHit(this.gameObject);
        }
        // �G�t�F�N�g�Đ�
        CommandEffectOnCollisionEnter(collision);
    }

    // �A�N�e�B�u��Ԃɂ���
    public void Activate()
    {
        isActive = true;
        meshRenderer.material = materialActive;
    }

    // ��A�N�e�B�u��Ԃɂ���
    public void Deactivate()
    {
        isActive = false;
        meshRenderer.material = materialStandard;
    }
}
