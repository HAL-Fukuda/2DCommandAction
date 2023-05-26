using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class DEAD_EFFECT : MonoBehaviour
{
    public PlayableDirector deadEffect;
    public float fadetime;

    // Start is called before the first frame update
    void Start()
    {
        deadEffect.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return))||(Input.anyKey))
        {
            // �G�t�F�N�g���I����Ă���V�[���J��
            if(deadEffect.time >= deadEffect.duration)
            {
                // ���݂̃V�[���ԍ���PlayerPrefs�ɕۑ�
                int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
                PlayerPrefs.SetInt("preSceneIdx", currentSceneIdx);
                // GameOver�V�[����
                FadeManager.Instance.LoadScene("GameOver", fadetime);
            }
            else
            {
                // �I����ĂȂ�������X�L�b�v
                deadEffect.time = deadEffect.duration;
            }
        }
    }
}
