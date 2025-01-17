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
              .AppendInterval(3)//三秒後
              .Append(transform.DOMoveY(0, 0.5f))//-1に6秒かけて向かう
              .Append(transform.DOMoveY(-5, 0.5f))//-7に6秒かけて向かう
              .SetLoops(-1);//ループさせる

        AudioSource.PlayClipAtPoint(se, transform.position);//SE

 
    }
}
