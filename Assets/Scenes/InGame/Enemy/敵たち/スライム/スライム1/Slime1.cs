using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime1: Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {
            base.FadeIn();
        }
    }
}
