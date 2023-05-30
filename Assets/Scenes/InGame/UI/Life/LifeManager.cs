using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;

    private PlayerManager PlayerManagerScript;

    public GameObject[] lifeArray = new GameObject[5];
    public int lifePoint = 5;
    public int maxlifePoint = 5;

    bool invincibility = false;

    public static float invincibilityTimer = 0.0f;

    public GameObject deadEffect; // 死亡エフェクト
    public GameObject deathSE;

    void Update()
    {
        // 被ダメージ時一定時間無敵
        if (invincibility == true && invincibilityTimer > 0.0f)
        {
            invincibilityTimer -= Time.deltaTime;

            if (invincibilityTimer <= 0.0f)
            {
                InvincibilityOff();
            }
        }
    }

    public void InvincibilityOn()
    {
        invincibility = true;
    }

    public void InvincibilityOff()
    {
        invincibility = false;
    }

    // 一定時間無敵にする
    // 引数：無敵時間（秒）
    public void InvincibilityWithTimer(float time)
    {
        invincibility = true;
        invincibilityTimer = time;
    }

    // 被ダメージ
    // 引数の値の文だけHPが減る
    public void GetDamage(int value)
    {
        if (invincibility == false)
        {
            // 被ダメージアニメーション
            playerManager.DamegeAnimation();

            // １秒無敵にする
            InvincibilityWithTimer(1.0f);

            for (int i = 0; i < value; i++)
            {
                if (lifePoint > 0)
                {
                    lifeArray[lifePoint - 1].SetActive(false);
                    lifePoint--;
                }
                if (lifePoint <= 0)
                {
                    // 死亡エフェクト生成
                    Instantiate(deadEffect);
                    Instantiate(deathSE);
                    playerManager.DieAnimation();
                    break;
                }
            }
        }
    }

    // 回復
    // 引数の値の数だけHPが増える
    public void GetHeal(int value)
    {
        for (int i = 0; i < value; i++)
        {
            if (lifePoint < maxlifePoint)
            {
                lifePoint++;
                lifeArray[lifePoint - 1].SetActive(true);
            }
            else
            {
                break;
            }
        }
    }

    public void Kill()
    {
        for (int i = 0; i < 99; i++)
        {
            if (lifePoint > 0)
            {
                lifeArray[lifePoint - 1].SetActive(false);
                lifePoint--;
            }
            if (lifePoint <= 0)
            {
                // 死亡エフェクト生成
                Instantiate(deadEffect);
                Instantiate(deathSE);
                playerManager.DieAnimation();
                break;
            }
        }
    }
}
