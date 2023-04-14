using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMgr : MonoBehaviour
{

    bool updateflag = true;
    [SerializeField] private GameObject AnyPress;
    [SerializeField] private GameObject Setting; // ���������ʂ�UI�I�u�W�F�N�g
    [SerializeField] private GameObject GameStart;
    [SerializeField] private GameObject Exit;

    void Start()
    {
        AnyPress.SetActive(true);
        Setting.SetActive(false);
        GameStart.SetActive(false);
        Exit.SetActive(false);
    }

    void Update()
    {
        StartTitle();
    }

    // �X�^�[�g�{�^���������ꂽ�Ƃ��̏���
    public void StartTitle()
    {
        if (Input.anyKey && updateflag == true)
        {
            updateflag = false;
            AnyPress.SetActive(false);
            Setting.SetActive(true);
            GameStart.SetActive(true);
            Exit.SetActive(true);
        }
    }
}
