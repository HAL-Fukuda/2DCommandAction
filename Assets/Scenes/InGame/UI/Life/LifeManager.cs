using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject[] lifeArray = new GameObject[5];
    public int lifePoint = 5;
    public int maxlifePoint = 5;

    bool invincibility = false;

    public GameObject deadEffect; // ���S�G�t�F�N�g

    public void InvincibilityOn()
    {
        invincibility = true;
    }

    public void InvincibilityOff()
    {
        invincibility = false;
    }

    // ��_���[�W
    // �����̒l�̕�����HP������
    public void GetDamage(int value)
    {
        if (invincibility == false)
        {
            for (int i = 0; i < value; i++)
            {
                if (lifePoint > 0)
                {
                    lifeArray[lifePoint - 1].SetActive(false);
                    lifePoint--;
                }
                if(lifePoint <= 0)
                {
                    // ���S�G�t�F�N�g����
                    Instantiate(deadEffect);
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
}
