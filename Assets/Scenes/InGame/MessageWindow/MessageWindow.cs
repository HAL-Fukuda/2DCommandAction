using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour
{
    // �R���X�g���N�^�� private �ɂ��邱�ƂŁA�N���X�̊O������̃C���X�^���X������h���i�V���O���g���p�^�[���j
    private MessageWindow() { }

    // ���̃N���X�̃C���X�^���X�i���X�N���v�g����Q�Ƃ���Ƃ��͂��̃C���X�^���X����čs���j
    private static MessageWindow instance = null;

    public static MessageWindow Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MessageWindow>(); // ���̏����d�������B
            }
            return instance;
        }
    }

    public Text debugText;
    public string message = "";
    private string oldMessage;

    // Start is called before the first frame update
    void Start()
    {
        // �e�L�X�g�R���|�[�l���g���擾����
        debugText = GetComponent<Text>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DrawMessage();
    }

    // ���b�Z�[�W���Z�b�g����
    public void SetDebugMessage(string text)
    {
        message = text;
    }

    public void ClearText()
    {
        // GameMgr��case���ς�������Ƀe�L�X�g���N���A����
        debugText.text = "";
    }

    private void DrawMessage()
    {
        if (!string.IsNullOrEmpty(message) && message != oldMessage)
        {
            // �e�L�X�g���N���A
            ClearText();
            // �f�o�b�O���b�Z�[�W�����s���ăe�L�X�g�ɒǉ�����
            debugText.text += message + "\n";
            oldMessage = message;
        }
    }
}
