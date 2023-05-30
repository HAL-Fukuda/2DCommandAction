using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brittle : MonoBehaviour
{
    public int maxHealth = 3; // �ő�HP
    public int currentHealth; // ���݂�HP
    public float recoveryTime = 5f; // �񕜂܂ł̎��ԁi�b�j
    private bool isRecovering = false; // �񕜒����ǂ����̃t���O
    Renderer objectRenderer;
    public Material materialAtHealth1;
    public Material materialAtHealth2;
    public Material materialAtHealth3;

    private float timer = 0.0f;

    private void Start()
    {
        currentHealth = maxHealth; // ������
        objectRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if ((timer >= recoveryTime) && (currentHealth >= 1 && currentHealth <= 2))
        {
            // �̗͉�
            currentHealth++;
            timer = 0; // �^�C�}�[���Z�b�g

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
                currentHealth--; // HP�����炷
                timer = 0.0f; // �^�C�}�[���Z�b�g

                if (currentHealth <= 0)
                {
                    Destroy(gameObject); // HP��0�ȉ��ɂȂ�����I�u�W�F�N�g��j�󂷂�
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
