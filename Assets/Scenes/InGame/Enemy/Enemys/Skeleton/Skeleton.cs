using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeOut)
        {
            base.StartFadeOut();
        }
    }
}