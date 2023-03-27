using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  //DOTweenを使うのに必要

public class CommandOperator : MonoBehaviour
{
    [SerializeField] Renderer rendererComponent;  //RendererComponentを取得
    [SerializeField] Vector3  targetPosition = new Vector3(1, 0, 0); //移動先の座標
    [SerializeField] Vector3  objectScale = new Vector3(1, 1, 1);  //変化後のサイズ
    [SerializeField] Ease     ease = Ease.Linear;  //始点と終点のつなぎ方

    [SerializeField] float duration = 1;    //移動に掛ける時間
    [SerializeField] float scaleTimer = 1;  //拡大・縮小までの時間
    [SerializeField] float jumpPower = 1;   //バウンドの高さ
    [SerializeField] int   numJump = 1;     //バウンドの回数
    [SerializeField] float colorTimer = 1;  //色が変わるまでの時間
    [SerializeField] float alpha = 1;       //フェード後のアルファ値 
    [SerializeField] float alphaTimer = 1;  //フェードに掛ける時間

    [SerializeField] bool CommandMoveStat = true;    //DOMoveを使うときtrue
    [SerializeField] bool CommandRotateStat = true;  //DORotateを使うときtrue
    [SerializeField] bool CommandScaleStat = true;   //DOScaleを使うときtrue
    [SerializeField] bool CommandJumpStat = true;    //DOJumpを使うときtrue
    [SerializeField] bool CommandPathStat = true;    //DOPathを使うときtrue
    [SerializeField] bool CommandColorStat = true;   //DOColorを使うときtrue
    [SerializeField] bool CommandFadeStat = true;    //DOFadeを使うときtrue

    Vector3[] path =
    {
        new Vector3(5,0.2349713f,0),
        new Vector3(5,3,0),
        new Vector3(10.46641f,3,0),
        new Vector3(10.46641f,0.2349713f,0)
    };

    void Start()
    {
        if (CommandMoveStat)
        {
            CommandMove();
            Debug.Log(CommandMoveStat);
        }
        else if (CommandRotateStat)
        {
            CommandRotate();
            Debug.Log(CommandRotateStat);
        }
        else if (CommandScaleStat)
        {
            CommandScale();
            Debug.Log(CommandScaleStat);
        }
        else if (CommandJumpStat)
        {
            CommandJump();
            Debug.Log(CommandJumpStat);
        }
        else if (CommandPathStat)
        {
            CommandPath();
            Debug.Log(CommandPathStat);
        }
        else if (CommandColorStat)
        {
            CommandColor();
            Debug.Log(CommandColorStat);
        }
        else if (CommandFadeStat)
        {
            CommandFade();
            Debug.Log(CommandFadeStat);
        }
    }

    
    void Update()
    {
        
    }

    //コマンドを移動させる処理
    void CommandMove()
    {
        //this.transform.DOMove(targetPosition, duration);  //ループしないやつ
        this.transform.DOMove(targetPosition, duration).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
        Debug.Log("CommandMove Active");
    }

    //コマンドを回転させる処理
    void CommandRotate()
    {
        //this.transform.DORotate(Vector3.up * 180f, 10f);  //ループしないやつ
        this.transform.DORotate(Vector3.up * 180f, 10f).SetLoops(-1, LoopType.Restart).SetEase(ease);
        Debug.Log("CommandRotate Active");
    }

    //コマンドを拡大・縮小させる処理（未実装）
    void CommandScale()
    {
        //this.transform.DOScale(objectScale, scaleTimer);  //ループしないやつ
        this.transform.DOScale(objectScale, scaleTimer).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
        Debug.Log("CommandScale Active");
    }

    //コマンドをバウンド移動させる処理
    void CommandJump()
    {
        //this.transform.DOJump(targetPosition, jumpPower, numJump, duration);  //ループしないやつ
        this.transform.DOJump(targetPosition, jumpPower, numJump, duration).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
        Debug.Log("CommandJump Active");
    }

    //コマンドを指定した位置を移動させる処理
    void CommandPath()
    {
        //this.transform.DOPath(path, duration);  //ループしないやつ
        this.transform.DOPath(path, duration).SetLoops(-1, LoopType.Restart).SetEase(ease);
        Debug.Log("CommandPath Active");
    }

    //コマンドの色を変える処理
    void CommandColor()
    {
        //this.rendererComponent.material.DOColor(Color.red, colorTimer); //ループしないやつ
        this.rendererComponent.material.DOColor(Color.red, colorTimer).SetLoops(-1,LoopType.Yoyo).SetEase(ease);
        Debug.Log("CommandColor Active");
    }

    //コマンドのアルファ値を変化させる処理（未実装）
    void CommandFade()
    {
        Debug.Log("CommandFade Active");
    }
}
