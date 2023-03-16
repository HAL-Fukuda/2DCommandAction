using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchObj : MonoBehaviour
{
    public float timer = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
