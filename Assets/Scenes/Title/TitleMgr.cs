using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMgr : MonoBehaviour
{
    bool updateflag = true;
    [SerializeField] private GameObject titleLogo; // �^�C�g����ʂ�UI�I�u�W�F�N�g
    [SerializeField] private GameObject StartLogo;
    [SerializeField] private GameObject Setting; // ���������ʂ�UI�I�u�W�F�N�g
    [SerializeField] private GameObject GameStartLogo;
    [SerializeField] private GameObject Exit;

    void Start()
    {
        StartLogo.SetActive(true);
        Setting.SetActive(false);
        GameStartLogo.SetActive(false);
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
            StartLogo.SetActive(false);
            Setting.SetActive(true);
            GameStartLogo.SetActive(true);
            Exit.SetActive(true);
        }
    }

    // ��������{�^���������ꂽ�Ƃ��̏���
    public void ShowInstructions()
    {

    }

    // ���������ʂ̖߂�{�^���������ꂽ�Ƃ��̏���
    public void HideInstructions()
    {

    }

    // �Q�[�����I������{�^���������ꂽ�Ƃ��̏���
    public void QuitGame()
    {
        Application.Quit();
    }
}
