using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunderbolt : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;
    float timer;
    bool oneceFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.1f) // ���G�t�F�N�g�𓧖��ɂ���
        {
            // �q�I�u�W�F�N�g�擾
            Transform thunder = transform.Find("thunder");
            // �X�v���C�g�����_���[�擾
            SpriteRenderer spriteRenderer = thunder.GetComponent<SpriteRenderer>();
            // �����ɂ���
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = 0f; // �A���t�@�l��0�ɐݒ�i���S�ɓ����j
            spriteRenderer.color = spriteColor;

            if (oneceFlag == false)
            {
                oneceFlag = true;
                Vector3 spawn = transform.position + new Vector3(0, 2.25f, 0);
                // ���e�G�t�F�N�g����
                Instantiate(explosion, spawn, Quaternion.identity);
            }
        }

        if (timer > 3.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
