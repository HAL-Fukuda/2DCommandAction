using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class elevator : MonoBehaviour
{
    public float movedistance = 2.0f;
    public float moveDuration = 2.0f; // ˆÚ“®‚É‚©‚©‚éŠÔ

    public bool UpTrigger = false;
    public bool DownTrigger = false;

    private bool isMovingUp = true; // Œ»İã¸’†‚©‚Ç‚¤‚©
    public float interval = 2.0f; // ã¸‚Æ‰º~‚ÌØ‚è‘Ö‚¦ŠÔŠÔŠu

    public bool isPaused = false;

    void Start()
    {
        // interval•b‚²‚Æ‚ÉChangeDirectionƒƒ\ƒbƒh‚ğŒJ‚è•Ô‚µŒÄ‚Ño‚·
        InvokeRepeating("ChangeDirection", interval, interval);
    }

    void ChangeDirection()
    {
        if (!isPaused)
        {
            isMovingUp = !isMovingUp;
            if (isMovingUp)
            {
                UpTrigger = true;
            }
            if (!isMovingUp)
            {
                DownTrigger = true;
            }
        }
    }

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
        UpTrigger = false;
    }

    public void DownUpdate()
    {
        transform.DOMoveY(transform.position.y - movedistance, moveDuration);
        DownTrigger = false;
    }
}
