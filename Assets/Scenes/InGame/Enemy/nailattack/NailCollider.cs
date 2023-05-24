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
    public float destroyTime;
    public AudioClip se;

    // Start is called before the first frame update
    void Start()
    {
        // Collider2Dコンポーネントを取得する
        collider = GetComponent<Collider2D>();
        //collider.isTrigger = false;
        // LifeManagerスクリプトがアタッチされているオブジェクトを取得する
        GameObject lifeManagerObject = GameObject.Find("Life");
        // LifeManagerコンポーネントを取得する
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
        objectRenderer = GetComponent<Renderer>();
        objectColor = objectRenderer.material.color;
        objectColor.a = 0f;
        objectRenderer.material.color = objectColor;
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTransparent)
        {
            objectColor.a += Time.deltaTime;
            objectRenderer.material.color = objectColor;
            if (objectColor.a >= 1f)
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
