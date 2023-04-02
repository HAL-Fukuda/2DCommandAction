using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour
{
    public Text debugText;

    // Start is called before the first frame update
    void Start()
    {
        // �e�L�X�g�R���|�[�l���g���擾����
        debugText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // GameMgr�̃f�o�b�O���b�Z�[�W���擾����
        string message = GameMgr.Instance.GetDebugMessage();
        if (!string.IsNullOrEmpty(message))
        {
            // �f�o�b�O���b�Z�[�W�����s���ăe�L�X�g�ɒǉ�����
            debugText.text += message + "\n";
        }
    }

    public void ClearText()
    {
        // GameMgr��case���ς�������Ƀe�L�X�g���N���A����
        debugText.text = "";
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
