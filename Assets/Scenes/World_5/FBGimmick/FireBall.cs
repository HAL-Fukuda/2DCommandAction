using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public AudioClip se;
    void Start()
    {
        DOTween.Sequence()
              .AppendInterval(3)//O•bŒã
              .Append(transform.DOMoveY(0, 0.5f))//-1‚É6•b‚©‚¯‚ÄŒü‚©‚¤
              .Append(transform.DOMoveY(-5, 0.5f))//-7‚É6•b‚©‚¯‚ÄŒü‚©‚¤
              .SetLoops(-1);//ƒ‹[ƒv‚³‚¹‚é

        AudioSource.PlayClipAtPoint(se, transform.position);//SE

 
    }
}
