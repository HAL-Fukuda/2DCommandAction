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
            if (battle == false)
            {
                FinalizeBattle();
            }
        }
    }

    // �G���Z�b�g����
    public void SetEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }

    // �G���폜����
    public void DeleteEnemy()
    {
        Destroy(this.enemy);
    }

    // �I�����ꂽ�R�}���h���i�[����
    public void SetCommand(GameObject command)
    {
        if (isCommandSelected) // ���łɃR�}���h���I������Ă���Ƃ�
        {
            // �I������Ă���R�}���h���폜
            DeleteCommand();
        }

        if(battleState == eBattleState.COMMAND_SELECT)
        {
            isCommandSelected = true;

            // �R�}���h���R�s�[
            selectedCommand = command;
        }
        else
        {
            Destroy(command);
        }
    }

    // �I�����ꂽ�R�}���h���폜����
    public void DeleteCommand()
    {
        isCommandSelected = false;

        Destroy(selectedCommand);
    }

    // �R�}���h���I������Ă��邩
    public bool IsCommandSelected()
    {
        return isCommandSelected;
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
}
