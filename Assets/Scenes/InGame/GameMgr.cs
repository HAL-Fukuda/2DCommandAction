using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        DEBUG,
    }
    public eBattleState battleState; // ���݂̃o�g���X�e�[�g
    public eBattleState? previousState; // ���O�̃o�g���X�e�[�g

    private GameObject selectedCommand; // �I�����ꂽ�R�}���h
    private bool isCommandSelected = false; // �R�}���h���I������Ă��邩

    public GameObject player; // �v���C���[�I�u�W�F�N�g
    public GameObject enemy; // �G�̃I�u�W�F�N�g
    // �v���g�^�C�v�łł͓G�𒼐ڎw�肷�邪�A����ύX����K�v������B

    public MessageWindow messageWindow;

    // �֐���`-------------------------

    // Start is called before the first frame update
    void Start()
    {
        ActiveTimeBattleInitialize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (battle)
        {
            // �퓬�X�V����
            ActiveTimeBattleUpdate();
            if(battle == false)
            {
                FinalizeBattle();
            }
        }
    }

    // �G���Z�b�g����
    public void StoreEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }

    // �I�����ꂽ�R�}���h���i�[����
    public void StoreCommand(GameObject command)
    {
        // �A�N�V�����o�[��100���̂Ƃ������R�}���h���󂯕t����
        if (playerActionBar.GetComponent<ActionBarControl>().IsReady())
        {
            isCommandSelected = true;
            this.selectedCommand = command;
        }
    }

    // �I�����ꂽ�R�}���h��null�ɂ���
    public void UnstoreCommand()
    {
        isCommandSelected = false;
        selectedCommand = null;
    }

    // �o�g�����J�n���邽�߂̏�����
    public void InitializeBattle()
    {
        // �E�B���h�E��\������
        // �G��z�u����
        // BGM�̍Đ�
    }

    // �o�g���I�����̏I������
    public void FinalizeBattle()
    {
        // �E�B���h�E�����
        // BGM���~����
    }

    // ���b�Z�[�W���擾����
    public string GetDebugMessage()
    {
        string message = "";

        // ���O�̃o�g���X�e�[�g�Ɣ�r
        if (previousState != battleState)
        {
            messageWindow.ClearText(); // MessageWindow�̃e�L�X�g���N���A����
            message = battleState.ToString(); // �X�e�[�g���ύX���ꂽ���̂ݕ\��
            previousState = battleState;
        }

        return message;
    }
}
