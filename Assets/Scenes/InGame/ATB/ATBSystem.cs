using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr : MonoBehaviour
{
    private float enemyTimer; // �G�l�~�[�p�^�C�}�[
    public const float enemyActionTime = 5.0f;

    private GameObject playerActionBar;
    private GameObject enemyActionBar;

    // ����������
    public void ActiveTimeBattleInitialize()
    {
        battleState = eBattleState.COMMAND_SELECT; // �o�g���X�e�[�g
        enemyTimer = enemyActionTime; // �G�l�~�[�p�^�C�}�[

        // �v���C���[�ƃG�l�~�[�̃o�[���擾
        Transform transform = player.transform.Find("ActionBar");
        playerActionBar = transform.gameObject;
        transform = enemy.transform.Find("ActionBar");
        enemyActionBar = transform.gameObject;
    }

    // ATB���̃V�X�e�����g�����퓬����
    public void ActiveTimeBattleUpdate()
    {
        // �o�g���X�e�[�g�ɉ���������
        switch (battleState)
        {
            case eBattleState.COMMAND_SELECT: // �ҋ@��
                // �A�N�V�����o�[���X�V����
                playerActionBar.gameObject.GetComponent<ActionBarControl>().ActionBarUpdate();
                enemyActionBar.gameObject.GetComponent<ActionBarControl>().ActionBarUpdate();

                // �A�N�V�����o�[���P�O�O���ɂȂ�����e�L�X�g��\������
                if (playerActionBar.GetComponent<ActionBarControl>().IsReady())
                {
                    string text = "�R�}���h��I�����Ă�������";
                    MessageWindow.Instance.SetDebugMessage(text);
                }

                // �s�����I�����ꂽ��o�g���X�e�[�g��ς���
                if (playerActionBar.GetComponent<ActionBarControl>().IsReady() &&
                    isCommandSelected == true)
                {
                    battleState = eBattleState.PLAYER;
                }
                if (enemyActionBar.GetComponent<ActionBarControl>().IsReady() &&
                    battleState == eBattleState.COMMAND_SELECT)
                {
                    string text = "�G�̍U���I";
                    MessageWindow.Instance.SetDebugMessage(text);

                    battleState = eBattleState.ENEMY;
                }
                break;

            case eBattleState.PLAYER: // �v���C���[

                // �A�N�V�����o�[��0���ɃZ�b�g
                playerActionBar.GetComponent<ActionBarControl>().SetEmpty();

                // �v���C���[�̍s��(�R�}���h�̏���)
                selectedCommand.GetComponent<Command>().CommandAction();

                // �R�}���h�̏������I��������o�g���X�e�[�g��ς���
                if (!selectedCommand.GetComponent<Command>().IsActive())
                {
                    UnstoreCommand(); // �I�����ꂽ�R�}���h�̏��𖳂���
                    battleState = eBattleState.COMMAND_SELECT;
                }
                break;

            case eBattleState.ENEMY: // �G�l�~�[

                enemyTimer -= Time.deltaTime;

                // �A�N�V�����o�[��0���ɃZ�b�g
                enemyActionBar.GetComponent<ActionBarControl>().SetEmpty();

                // �G�̍s��
                enemy.GetComponent<EnemyAttack>().MeteorAttack();

                // ���Ԃ��o������G�̍s���I��
                if (enemyTimer <= 0.0f)
                {
                    enemyTimer = enemyActionTime;
                    battleState = eBattleState.COMMAND_SELECT;
                }
                break;
        }
    }
}