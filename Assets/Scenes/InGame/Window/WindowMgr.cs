using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class WindowMgr : MonoBehaviour
{ 
    // �R���X�g���N�^�� private �ɂ��邱�ƂŁA�N���X�̊O������̃C���X�^���X������h���i�V���O���g���p�^�[���j
    private WindowMgr() { }

    // ���̃N���X�̃C���X�^���X�i���X�N���v�g����Q�Ƃ���Ƃ��͂��̃C���X�^���X����čs���j
    private static WindowMgr instance = null;

    public static WindowMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WindowMgr();
            }
            return instance;
        }
    }

    // �ϐ���`-------------------------


    // �֐���`-------------------------

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
