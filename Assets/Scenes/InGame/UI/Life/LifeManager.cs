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

    public GameObject deadEffect; // ���S�G�t�F�N�g
    public GameObject deathSE;

    void Update()
    {
        // ��_���[�W����莞�Ԗ��G
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

    // ��莞�Ԗ��G�ɂ���
    // �����F���G���ԁi�b�j
    public void InvincibilityWithTimer(float time)
    {
        invincibility = true;
        invincibilityTimer = time;
    }

    // ��_���[�W
    // �����̒l�̕�����HP������
    public void GetDamage(int value)
    {
        if (invincibility == false)
        {
            // ��_���[�W�A�j���[�V����
            playerManager.DamegeAnimation();

            // �P�b���G�ɂ���
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
                    // ���S�G�t�F�N�g����
                    Instantiate(deadEffect);
                    Instantiate(deathSE);
                    playerManager.DieAnimation();
                    break;
                }
            }
        }
    }

    // ��
    // �����̒l�̐�����HP��������
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
                // ���S�G�t�F�N�g����
                Instantiate(deadEffect);
                Instantiate(deathSE);
                playerManager.DieAnimation();
                break;
            }
        }
    }
}
