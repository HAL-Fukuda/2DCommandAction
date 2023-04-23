using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton1 : Enemy
{
    
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
        if (isFadeOut)
        {
            base.StartFadeOut();
        }
    }
}
