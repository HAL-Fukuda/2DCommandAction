using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class elevator : MonoBehaviour
{
    public float movedistance = 2.0f;
    public float moveDuration = 2.0f; // ˆÚ“®‚É‚©‚©‚éŽžŠÔ

    private bool UpTrigger = false;
    private bool DownTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UpTrigger)
        {
            UpUpdate();
        }
        if (DownTrigger)
        {
            DownUpdate();
        }
    }

    public void UpUpdate()
    {
        transform.DOMoveY(transform.position.y + movedistance, moveDuration);
    }

    public void DownUpdate()
    {
        transform.DOMoveY(transform.position.y - movedistance, moveDuration);
    }
}
