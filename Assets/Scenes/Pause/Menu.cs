using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button stageselectButton;

    //public PlayerManager playerManager;

    void Start()
    {
        pausePanel.SetActive(false);
        resumeButton.onClick.AddListener(Resume);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Pause();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;  // éûä‘í‚é~
        pausePanel.SetActive(true);
        //playerManager.isMove = false;
    }

    private void Resume()
    {
        Time.timeScale = 1;  // çƒäJ
        pausePanel.SetActive(false);
        //playerManager.isMove = true;
    }
}