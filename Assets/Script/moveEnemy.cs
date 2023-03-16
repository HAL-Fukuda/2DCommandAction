using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        // transform‚ğæ“¾
        Transform myTransform = this.transform;

        // À•W‚ğæ“¾
        Vector3 pos = myTransform.position;

        if (true)
        {
            rb.useGravity = true;
        }
        else
        {
            rb.useGravity = false;
        }

        if (rb.useGravity == false && pos.y < 4)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 5.0f);
        }
    }
}