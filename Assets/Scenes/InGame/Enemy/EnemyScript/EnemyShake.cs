using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public partial class EnemyAttack : MonoBehaviour
{
    private static Tweener shakeTweener;
    private Vector3 initPosition;

    private void Start()
    {
        // 初期位置を保持
        initPosition = transform.position;
    }

    /// <summary>
    /// 揺れ開始
    /// </summary>
    /// <param name="duration">時間</param>
    /// <param name="strength">揺れの強さ</param>
    /// <param name="vibrato">どのくらい振動するか</param>
    /// <param name="randomness">ランダム度合(0?180)</param>
    /// <param name="fadeOut">フェードアウトするか</param>
    public void StartShake()
    {
        // 前回の処理が残っていれば停止して初期位置に戻す
        if (shakeTweener != null)
        {
            shakeTweener.Kill();
            gameObject.transform.position = initPosition;
        }
        // 揺れ開始
        // 数字そのままねじ込んでるけど意味はコメントの上から参照して
        shakeTweener = gameObject.transform.DOShakePosition(2.0f, 0.1f, 30, 90.0f, false).OnComplete(() =>
        {
            IsReadyOn();
        });
    }
}