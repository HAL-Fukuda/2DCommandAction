using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffectRange : MonoBehaviour
{
    private float timer;  //��������̎���

    void Start()
    {
        timer = 0f; 
    }
    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3f)
        {
            Destroy(this.gameObject);
        }
    }
}
