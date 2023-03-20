using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr : MonoBehaviour
{
    // �R���X�g���N�^�� private �ɂ��邱�ƂŁA�N���X�̊O������̃C���X�^���X������h���i�V���O���g���p�^�[���j
    private GameMgr() { }

    // ���̃N���X�̃C���X�^���X�i���X�N���v�g����Q�Ƃ���Ƃ��͂��̃C���X�^���X����čs���j
    private static GameMgr instance = null; 
   
    public static GameMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameMgr>(); // ���̏����d�������B
            }
            return instance;
        }
    }


    // �ϐ���`-------------------------

    public bool battle = true; // �퓬�����ǂ���
    
    // �o�g���X�e�[�g
    public enum eBattleState
    {
        COMMAND_SELECT,
        PLAYER,
        ENEMY,
    }
    public eBattleState battleState; // ���݂̃o�g���X�e�[�g

    private GameObject selectedCommand; // �I�����ꂽ�R�}���h

    private GameObject enemy; // �G�̃I�u�W�F�N�g

    private eBattleState previousState; // ���O�̃o�g���X�e�[�g

    // �֐���`-------------------------

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (battle)
        {
            // �퓬�X�V����
            BattleUpdate();
        }
    }

    // �G���Z�b�g����
    public void SetEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }

    // �I�����ꂽ�R�}���h���Z�b�g����
    public void SetCommand(GameObject command)
    {
        this.selectedCommand = command;
    }

    // �o�g�����J�n���邽�߂̏�����
    public void InitializeBattle()
    {
        battle = true;
        battleState = eBattleState.COMMAND_SELECT;
        selectedCommand = null;
        CommandMgr.Instance.DeactivateALL();
    }

    private void BattleUpdate()
    {
        // �o�g���X�e�[�g�ɉ���������
        switch (battleState)
        {
            case eBattleState.COMMAND_SELECT: // �R�}���h�I��
                if(selectedCommand != null && selectedCommand.GetComponent<Command>().IsActive())
                {
                    // �R�}���h���I������Ă�����v���C���[�̍s����
                    battleState = eBattleState.PLAYER;
                }
                Debug.Log("�R�}���h�I��");
                break;

            case eBattleState.PLAYER: // �v���C���[�̍s��
                if (selectedCommand != null)
                {
                    // �I�����ꂽ�R�}���h�ɉ���������
                    switch (selectedCommand.GetComponent<Command>().commandType)
                    {
                        case Command.eCommandType.ATTACK: // ��������
                            Debug.Log("ATTACK");
                            break;
                        case Command.eCommandType.ITEM: // �A�C�e��
                            Debug.Log("ITEM");
                            break;
                    }
                    // �R�}���h�����Z�b�g����
                    selectedCommand = null;
                    CommandMgr.Instance.DeactivateALL();
                    // �G�̍s����
                    battleState = eBattleState.ENEMY;
                }
                Debug.Log("�v���C���[�̍s��");
                break;

            case eBattleState.ENEMY: // �G�̍s��
                //enemy.GetComponent<Enemy>().Action();
                //if (enemy.GetComponent<Enemy>().IsActive() != true)
                //{
                //    battleState = eBattleState.COMMAND_SELECT;
                //}

                Debug.Log("�G�̍s��");
                break;
        }
    }

    // �f�o�b�O�p�Ƀ��b�Z�[�W���擾����
    public string GetDebugMessage()
    {
        string message = "";

        // ���O�̃o�g���X�e�[�g�Ɣ�r
        if (previousState != battleState)
        {
            message = "�y" + battleState.ToString() + "�z"; // �X�e�[�g���ύX���ꂽ�Ƃ��̂ݕ\��
            previousState = battleState;
        }

        //switch (battleState)
        //{
        //    case eBattleState.COMMAND_SELECT: // �R�}���h�I��
        //        message = "�R�}���h�I��";
        //        break;

        //    case eBattleState.PLAYER: // �v���C���[�̍s��
        //        message = "�v���C���[�̍s����";
        //        break;

        //    case eBattleState.ENEMY: // �G�̍s��
        //        message = "�G�̍s����";
        //        break;
        //}
        return message;
    }
}
