using UnityEngine;
using System.Collections;

public class SwitchMaterial : MonoBehaviour
{
    public Material material1; // 切り替えるマテリアル1
    public Material material2; // 切り替えるマテリアル2
    public float switchTime = 2f; // マテリアルを切り替える間隔

    private Renderer objectRenderer;
    private float timer = 0f;
    private bool isMaterial1 = true;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchTime)
        {
            timer = 0f;
            isMaterial1 = !isMaterial1;

            if (isMaterial1)
            {
                objectRenderer.material = material1;
            }
            else
            {
                objectRenderer.material = material2;
            }
        }
    }
}
