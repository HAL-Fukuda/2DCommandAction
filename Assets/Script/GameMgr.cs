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
    private enum eBattleState
    {
        COMMAND_SELECT,
        PLAYER,
        ENEMY,
    }
    private eBattleState battleState; // ���݂̃o�g���X�e�[�g

    private GameObject selectedCommand; // �I�����ꂽ�R�}���h

    public GameObject enemy; // �G�̃I�u�W�F�N�g
    // �v���g�^�C�v�łł͓G�𒼐ڎw�肷�邪�A����ύX����K�v������B

    private bool runningCoroutine;

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
        // �ϐ��̏�����
        battle = true;
        battleState = eBattleState.COMMAND_SELECT;
        selectedCommand = null;
        CommandMgr.Instance.DeactivateALL();

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

    private void BattleUpdate()
    {
        // �o�g���X�e�[�g�ɉ���������
        switch (battleState)
        {
            case eBattleState.COMMAND_SELECT: // �R�}���h�I��
                Debug.Log("�R�}���h�I��");
                if (selectedCommand != null && selectedCommand.GetComponent<Command>().IsActive())
                {
                    // �R�}���h���I������Ă����班���҂��ăv���C���[�̍s����
                    if (runningCoroutine != true)
                    {
                        StartCoroutine(ToPlayerAction(2));
                    }
                }
                break;

            case eBattleState.PLAYER: // �v���C���[�̍s��
                Debug.Log("�v���C���[�̍s��");
                if (selectedCommand != null)
                {
                    // �I�����ꂽ�R�}���h�ɉ���������
                    switch (selectedCommand.GetComponent<Command>().commandType)
                    {
                        case Command.eCommandType.ATTACK: // ��������
                            Debug.Log("ATTACK");

                            // �G���n�ʂɍ~��Ă���
                            //enemy.GetComponent<Enemy>.ToGround();
                            EnemyToGround();

                            // ��莞�Ԍ�ɃE�B���h�E�ɖ߂�
                            StartCoroutine(EnemyToWindow(2));

                            break;
                        case Command.eCommandType.ITEM: // �A�C�e��
                            Debug.Log("ITEM");
                            break;
                    }
                    // �G�̍s����
                    battleState = eBattleState.ENEMY;
                }
                else
                {
                    Debug.Log("selectedCommand��null");
                }
                break;

            case eBattleState.ENEMY: // �G�̍s��
                Debug.Log("�G�̍s��");
                if (enemy != null)
                {
                    // �����Q
                    enemy.GetComponent<EnemyAttack>().MeteorAttack();

                    // ��莞�Ԍ�ɃR�}���h��\�����ăR�}���h�Z���N�g��
                    if (runningCoroutine != true)
                    {
                        StartCoroutine(ToCommandSelect(5));
                    }
                }
                break;
        }
    }

    // ���v���C���[�̍s���ֈڍs
    private IEnumerator ToPlayerAction(float delay)
    {
        runningCoroutine = true;

        // ��莞�ԑҋ@
        yield return new WaitForSeconds(delay);

        // �v���C���[�̍s���ֈڍs����
        battleState = eBattleState.PLAYER;
        CommandMgr.Instance.HideCommand();
        Debug.Log("�v���C���[�̍s����");

        // �R���[�`���������������Ƃ��������߂� null ��Ԃ�
        runningCoroutine = false;
        yield return null;
    }

    // ���R�}���h�Z���N�g�ֈڍs
    private IEnumerator ToCommandSelect(float delay)
    {
        runningCoroutine = true;

        yield return new WaitForSeconds(delay);

        // �R�}���h�����Z�b�g����
        CommandMgr.Instance.ShowCommand();
        selectedCommand = null;
        CommandMgr.Instance.DeactivateALL();

        battleState = eBattleState.COMMAND_SELECT;

        Debug.Log("�R�}���h�Z���N�g��");

        // �R���[�`���������������Ƃ��������߂� null ��Ԃ�
        runningCoroutine = false;
        yield return null;
    }

    // ��莞�ԑҋ@���Ă���G���E�B���h�E�Ɉړ�����
    private IEnumerator EnemyToWindow(float delay)
    {
        runningCoroutine = true;

        // ��莞�ԑҋ@
        yield return new WaitForSeconds(delay);
        // �E�B���h�E�ֈړ�
        EnemyToWindow();

        // �R���[�`���������������Ƃ��������߂� null ��Ԃ�
        runningCoroutine = false;
        yield return null;
    }

    // �f�o�b�O
    void EnemyToGround()
    {
        Debug.Log("�G���n�ʂɈړ�����");
    }

    void EnemyToWindow()
    {
        Debug.Log("�G���E�B���h�E�Ɉړ�����");
    }
}
