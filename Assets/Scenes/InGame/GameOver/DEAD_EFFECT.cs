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
            // エフェクトが終わってたらシーン遷移
            if(deadEffect.time >= deadEffect.duration)
            {
                // 現在のシーン番号をPlayerPrefsに保存
                int currentSceneIdx = SceneManager.GetActiveScene().buildIndex;
                PlayerPrefs.SetInt("preSceneIdx", currentSceneIdx);
                // GameOverシーンへ
                FadeManager.Instance.LoadScene("GameOver", fadetime);
            }
            else
            {
                // 終わってなかったらスキップ
                deadEffect.time = deadEffect.duration;
            }
        }
    }
}
