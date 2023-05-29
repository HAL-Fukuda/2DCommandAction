using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailCollider : MonoBehaviour
{
    private LifeManager lifeManager;
    private Renderer objectRenderer;
    private Collider2D collider;
    private Color objectColor;
    private bool isTransparent = true;
    public float fadeTime = 1f; // �����x��1�ɂȂ�܂ł̎��ԁi�b�j
    public AudioClip se;

    private float currentAlpha = 0f;
    private float fadeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Collider2D�R���|�[�l���g���擾����
        collider = GetComponent<Collider2D>();
        //collider.isTrigger = false;
        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject lifeManagerObject = GameObject.Find("Life");
        // LifeManager�R���|�[�l���g���擾����
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
        objectRenderer = GetComponent<Renderer>();
        objectColor = objectRenderer.material.color;
        objectColor.a = 0f;
        objectRenderer.material.color = objectColor;

        fadeSpeed = 1f / fadeTime; // �t�F�[�h���x���v�Z
        Destroy(gameObject, fadeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTransparent)
        {
            currentAlpha += fadeSpeed * Time.deltaTime;
            objectColor.a = Mathf.Lerp(0f, 1f, currentAlpha);
            objectRenderer.material.color = objectColor;
            if (currentAlpha >= 1f)
            {
                isTransparent = false;
                collider.isTrigger = true;
                AudioSource.PlayClipAtPoint(se, transform.position);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isTransparent == false && collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
            //Destroy(gameObject);
        }
    }
}
