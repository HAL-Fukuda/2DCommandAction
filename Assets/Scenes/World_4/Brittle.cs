using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brittle : MonoBehaviour
{
    public int maxHealth = 3; // �ő�HP
    public int currentHealth; // ���݂�HP
    Renderer objectRenderer;
    public Material newMaterial;

    private void Start()
    {
        currentHealth = maxHealth; // ������
        objectRenderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager playerManager = collision.GetComponent<PlayerManager>();
            if (!playerManager.isGround)
            {
                currentHealth--; // HP�����炷

                if (currentHealth <= 0)
                {
                    Destroy(gameObject); // HP��0�ȉ��ɂȂ�����I�u�W�F�N�g��j�󂷂�
                }
                else if (currentHealth == 1)
                {
                    objectRenderer.material = newMaterial;
                }
            }
        }
    }
}
