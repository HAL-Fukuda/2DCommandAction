using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Magma : MonoBehaviour
{

    public AudioClip se;
    void Start()
    {
        // 無限ループ
        DOTween.Sequence()
              .AppendInterval(3)//三秒後
              .Append(transform.DOMoveY(-1, 6))//-1に6秒かけて向かう
              .AppendInterval(3)//三秒後
              .Append(transform.DOMoveY(-7, 6))//-7に6秒かけて向かう
              .SetLoops(-1);//ループさせる

        AudioSource.PlayClipAtPoint(se, transform.position);//SE
    }
}
