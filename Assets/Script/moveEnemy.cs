using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float gravityScale = 1f;
    //private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;

        //renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {

        // transform‚ğæ“¾
        Transform myTransform = this.transform;

        // À•W‚ğæ“¾
        Vector3 pos = myTransform.position;

        if (Input.GetKey(KeyCode.Z))
        {
            rb.gravityScale = 1f;
            //renderer.material.color = Color.red;
        }
        else
        {
            rb.gravityScale = 0f;
            //renderer.material.color = Color.white;
        }

        if (rb.gravityScale == 0f && pos.y < 4)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 5.0f);
        }

    }
}