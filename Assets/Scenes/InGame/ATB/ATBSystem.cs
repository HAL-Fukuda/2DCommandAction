using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameMgr : MonoBehaviour
{
    // ATB���̃V�X�e�����g�����퓬����
    public void ActiveTimeBattleUpdate()
    {
        // �o�g���X�e�[�g�ɉ���������
        switch (battleState)
        {
            case eBattleState.COMMAND_SELECT: // �ҋ@��

                // �A�N�V�����o�[���X�V����
                //enemy.GetComponent<ActionBarControl>().ActionBarUpdate();
                //player.GetComponent<ActionBarControl>().ActionBarUpdate();

                // �s�����I�����ꂽ��o�g���X�e�[�g��ς���
                //if (player.GetComponent<ActionBarControl>().IsReady())
                if (false)
                {
                    battleState = eBattleState.PLAYER;
                }
                //if (enemy.GetComponent<ActionBarControl>().IsReady())
                if (false)
                {
                    battleState = eBattleState.ENEMY;

                }
                break;

            case eBattleState.PLAYER: // �ҋ@��

                // �A�N�V�����o�[��0���ɃZ�b�g
                //player.GetComponent<ActionBarControl>().SetEmpty();

                // �v���C���[�̍s��(�R�}���h�̏���)
                CommandUpdate();

                // �R�}���h�̏������I��������o�g���X�e�[�g��ς���
                //CommandMgr.Instance().IsAction(); // ���������ǂ���
                if (true)
                {
                    battleState = eBattleState.COMMAND_SELECT;
                }
                break;

            case eBattleState.ENEMY: // �ҋ@��

                // �A�N�V�����o�[��0���ɃZ�b�g
                //enemy.GetComponent<ActionBarControl>().SetEmpty();
                
                // �G�̍s��
                EnemyUpdate();

                // �s�����I��������o�g���X�e�[�g��ς���
                //EnemyMgr.Instance().IsAction(); // ���������ǂ���
                if (true)
                {
                    battleState = eBattleState.COMMAND_SELECT;
                }
                break;
        }
    }

    private void CommandUpdate()
    {
        // �R�}���h�̏��������s
        //CommandMgr.Instance().Action();
    }

    private void EnemyUpdate()
    {
        // �G�̍U��
        //EnemyMgr.Instance().Action();
    }
}

