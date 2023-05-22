using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderExplosion : MonoBehaviour
{
    float timer;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;

        // �X�v���C�g�����_���[�擾
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.3f)
        {
            // �����ɂ���
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = 0f; // �A���t�@�l��0�ɐݒ�i���S�ɓ����j
            spriteRenderer.color = spriteColor;
        }

        if(timer > 5.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
