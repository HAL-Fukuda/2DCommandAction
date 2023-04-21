using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Enemy
{
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        //    if (Input.GetKey(KeyCode.K))
        //    {
        //        isFadeOut = true;
        //    }
        //    if (isFadeOut)
        //    {
        //        base.StartFadeOut();
        //        //Debug.Log("Fade");
        //    }

        if (isFadeIn)
        {
            base.StartFadeIn();
        }
    }
}
