using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brittle : MonoBehaviour
{
    public int maxHealth = 3; // 最大HP
    public int currentHealth; // 現在のHP
    public float recoveryTime = 5f; // 回復までの時間（秒）
    private bool isRecovering = false; // 回復中かどうかのフラグ
    Renderer objectRenderer;
    public Material materialAtHealth1;
    public Material materialAtHealth2;
    public Material materialAtHealth3;

    private float timer = 0.0f;

    private void Start()
    {
        currentHealth = maxHealth; // 初期化
        objectRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if ((timer >= recoveryTime) && (currentHealth >= 1 && currentHealth <= 2))
        {
            // 体力回復
            currentHealth++;
            timer = 0; // タイマーリセット

            if (currentHealth == 1)
            {
                objectRenderer.material = materialAtHealth1;
            }
            else if (currentHealth == 2)
            {
                objectRenderer.material = materialAtHealth2;
            }
            else if (currentHealth == 3)
            {
                objectRenderer.material = materialAtHealth3;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager playerManager = collision.GetComponent<PlayerManager>();
            if (!playerManager.isGround && !isRecovering)
            {
                currentHealth--; // HPを減らす
                timer = 0.0f; // タイマーリセット

                if (currentHealth <= 0)
                {
                    Destroy(gameObject); // HPが0以下になったらオブジェクトを破壊する
                }

                if (currentHealth == 1)
                {
                    objectRenderer.material = materialAtHealth1;
                }
                else if (currentHealth == 2)
                {
                    objectRenderer.material = materialAtHealth2;
                }
                else if (currentHealth == 3)
                {
                    objectRenderer.material = materialAtHealth3;
                }

            }
        }
    }
}
