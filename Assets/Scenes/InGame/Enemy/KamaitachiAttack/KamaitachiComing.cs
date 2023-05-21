using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamaitachiComing : MonoBehaviour
{
    private float timer;  //

    public bool isFadeIn = true;  //
    private float fadeInSpeed = 0.1f;  //
    private float red, green, blue, alfa;  //
    private Renderer fadeMaterial;  //

    void Start()
    {
        timer = 0f;

        fadeMaterial = GetComponent<Renderer>();
        red = fadeMaterial.material.color.r;
        green = fadeMaterial.material.color.g;
        blue = fadeMaterial.material.color.b;
        alfa = fadeMaterial.material.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (isFadeIn)
        {
            FadeIn();
        }

        if (timer >= 3.5f)
        {
            Destroy(this.gameObject);
        }
    }

    void FadeIn()
    {
        fadeMaterial.enabled = true;
        alfa += fadeInSpeed;
        SetAlfa();

        if (alfa >= 0.5f)
        {
            isFadeIn = false;
            Debug.Log(timer);
        }
    }

    void SetAlfa()
    {
        fadeMaterial.material.color = new Color(red, green, blue, alfa);
    }
}
