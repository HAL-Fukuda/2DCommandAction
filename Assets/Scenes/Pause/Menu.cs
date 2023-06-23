using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button stageselectButton;

    public Pause pauseScript;
    public GameObject player;
    private bool pauseNow;
    //public PlayerManager playerManager;

    void Start()
    {
        pauseNow = false;
        pausePanel.SetActive(false);
        resumeButton.onClick.AddListener(Resume);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || (Input.GetButtonDown("pause"))) && (pauseNow == false))
        {
            Pause();
            pauseScript.InitializePause();
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) || (Input.GetButtonDown("pause")) && (pauseNow == true)))
        {
            Resume();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;  // éûä‘í‚é~
        pausePanel.SetActive(true);
        player.SetActive(false);
        //playerManager.isMove = false;
        pauseNow = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;  // çƒäJ
        pausePanel.SetActive(false);
        player.SetActive(true);
        //playerManager.isMove = true;
        pauseNow = false;
    }
}