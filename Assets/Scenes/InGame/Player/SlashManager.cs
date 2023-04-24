using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashManager : MonoBehaviour
{
    private float SPEED = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x += SPEED;
        transform.position = position;
    }
}