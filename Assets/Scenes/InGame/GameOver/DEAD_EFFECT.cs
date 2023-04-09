using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class DEAD_EFFECT : MonoBehaviour
{
    public PlayableDirector deadEffect;

    // Start is called before the first frame update
    void Start()
    {
        deadEffect.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // エフェクトが終わってたらシーン遷移
            if(deadEffect.time >= deadEffect.duration)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                // 終わってなかったらスキップ
                deadEffect.time = deadEffect.duration;
            }
        }
    }
}
