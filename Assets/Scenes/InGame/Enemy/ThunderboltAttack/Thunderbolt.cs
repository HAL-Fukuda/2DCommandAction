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
            if (oneceFlag == false)
            {
                oneceFlag = true;

                // �q�v�f���擾
                Transform colliderObject = this.transform.Find("thunderCollider");
                // �����ɂ���
                SpriteRenderer spriteRenderer = colliderObject.GetComponent<SpriteRenderer>();
                Color spriteColor = spriteRenderer.color;
                spriteColor.a = 0f; // �A���t�@�l��0�ɐݒ�i���S�ɓ����j
                spriteRenderer.color = spriteColor;
                // �����蔻�������
                BoxCollider2D boxCollider = colliderObject.GetComponent<BoxCollider2D>();
                boxCollider.enabled = false;

                // ���e�G�t�F�N�g����
                Vector3 spawn = transform.position + new Vector3(0, 2.25f, 0);
                Instantiate(explosion, spawn, Quaternion.identity);
            }
        }

        if (timer > 3.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
