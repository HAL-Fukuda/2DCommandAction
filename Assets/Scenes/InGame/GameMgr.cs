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
        ENEMY_DIE,
        NEXT_FLOOR,
        DEBUG,
    }
    public eBattleState battleState; // ���݂̃o�g���X�e�[�g
    public eBattleState? previousState; // ���O�̃o�g���X�e�[�g

    private GameObject selectedCommand; // �I�����ꂽ�R�}���h
    private bool isCommandSelected = false; // �R�}���h���I������Ă��邩

    public GameObject player; // �v���C���[�I�u�W�F�N�g
    private GameObject enemy; // �G�̃I�u�W�F�N�g

    private bool killedEnemy = false; // �G��|�������ǂ���
    private int killCount = 0; // �G��|������

    private bool stageClear = false;
    public GameObject stageClearEffectPrefab; // �X�e�[�W�N���A���o
    
    public int battleNum;  //�o�g������ݒ肷��ϐ�(�e�X�e�[�W�Őݒ肷��)
    public bool deathFlag = false;  //�G�������Ă��邩�ǂ���

    // �X�N���v�g��`
    private CommandMgr commandMgr;

    // �֐���`-------------------------

    // Start is called before the first frame update
    void Start()
    {
        stageClear = false;
        SpawnEnemy();
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

    private void StageClear()
    {
        battle = false;
        Instantiate(stageClearEffectPrefab);
    }

    // �G�𐶐�����
    public void SpawnEnemy()
    {
        // �G�l�~�[�𐶐�
        EnemyMgr script = GetComponent<EnemyMgr>();
        script.SpawnEnemy(killCount);
        // �G�l�~�[�̃I�u�W�F�N�g���擾
        enemy = script.GetEnemyData();
        // �A�N�V�����o�[���擾
        Transform transform = enemy.transform.Find("ActionBar");
        enemyActionBar = transform.gameObject;
        // �t���O�����Z�b�g
        killedEnemy = false;
    }

    // �G���폜����
    public void DeleteEnemy()
    {   
        killedEnemy = true;
        killCount++;
        // �R�̓|������X�e�[�W�N���A
        if(killCount == battleNum)
        {
            stageClear = true;
        }
    }

    // �I�����ꂽ�R�}���h���i�[����
    public void SetCommand(GameObject command)
    {
        if (isCommandSelected) // ���łɃR�}���h���I������Ă���Ƃ�
        {
            // �I������Ă���R�}���h���폜
            Destroy(command);
        }

        if (battleState == eBattleState.COMMAND_SELECT && // �R�}���h�Z���N�g�̎�
            playerActionBar.GetComponent<ActionBarControl>().IsReady()) // �A�N�V�����o�[���P�O�O���̎�
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

    public void DeathFlagChenge()
    {
        deathFlag = true;
    }
}
