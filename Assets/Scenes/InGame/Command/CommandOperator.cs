using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  //DOTween���g���̂ɕK�v

public partial class Command : MonoBehaviour
{
    [SerializeField] Renderer rendererComponent;  //RendererComponent���擾
    [SerializeField] Vector3  targetPosition = new Vector3(1, 0, 0); //�ړ���̍��W
    [SerializeField] Vector3  objectScale = new Vector3(1, 1, 1);  //�ω���̃T�C�Y
    [SerializeField] Ease     ease = Ease.Linear;  //�n�_�ƏI�_�̂Ȃ���

    [SerializeField] float duration = 1;    //�ړ��Ɋ|���鎞��
    [SerializeField] float scaleTimer = 1;  //�g��E�k���܂ł̎���
    [SerializeField] float jumpPower = 1;   //�o�E���h�̍���
    [SerializeField] int   numJump = 1;     //�o�E���h�̉�
    [SerializeField] float colorTimer = 1;  //�F���ς��܂ł̎���
    [SerializeField] float alpha = 1;       //�t�F�[�h��̃A���t�@�l 
    [SerializeField] float alphaTimer = 1;  //�t�F�[�h�Ɋ|���鎞��

    [SerializeField] bool CommandMoveStat = true;    //DOMove���g���Ƃ�true
    [SerializeField] bool CommandRotateStat = true;  //DORotate���g���Ƃ�true
    [SerializeField] bool CommandScaleStat = true;   //DOScale���g���Ƃ�true
    [SerializeField] bool CommandJumpStat = true;    //DOJump���g���Ƃ�true
    [SerializeField] bool CommandPathStat = true;    //DOPath���g���Ƃ�true
    [SerializeField] bool CommandColorStat = true;   //DOColor���g���Ƃ�true
    [SerializeField] bool CommandFadeStat = true;    //DOFade���g���Ƃ�true

    Vector3[] path =
    {
        new Vector3(5,0.2349713f,0),
        new Vector3(5,3,0),
        new Vector3(10.46641f,3,0),
        new Vector3(10.46641f,0.2349713f,0)
    };

    void CommandOperatorInitialize()
    {
        if (CommandMoveStat)
        {
            CommandMove();
            //Debug.Log(CommandMoveStat);
        }
        else if (CommandRotateStat)
        {
            CommandRotate();
            //Debug.Log(CommandRotateStat);
        }
        else if (CommandScaleStat)
        {
            CommandScale();
            //Debug.Log(CommandScaleStat);
        }
        else if (CommandJumpStat)
        {
            CommandJump();
            //Debug.Log(CommandJumpStat);
        }
        else if (CommandPathStat)
        {
            CommandPath();
            //Debug.Log(CommandPathStat);
        }
        else if (CommandColorStat)
        {
            CommandColor();
            //Debug.Log(CommandColorStat);
        }
        else if (CommandFadeStat)
        {
            CommandFade();
            //Debug.Log(CommandFadeStat);
        }
    }

    
    void CommandOperatorUpdate()
    {
        
    }

    //�R�}���h���ړ������鏈��
    void CommandMove()
    {
        //this.transform.DOMove(targetPosition, duration);  //���[�v���Ȃ����
        this.transform.DOMove(targetPosition, duration).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
        //Debug.Log("CommandMove Active");
    }

    //�R�}���h����]�����鏈��
    void CommandRotate()
    {
        //this.transform.DORotate(Vector3.up * 180f, 10f);  //���[�v���Ȃ����
        this.transform.DORotate(Vector3.up * 180f, 10f).SetLoops(-1, LoopType.Restart).SetEase(ease);
        //Debug.Log("CommandRotate Active");
    }

    //�R�}���h���g��E�k�������鏈���i�������j
    void CommandScale()
    {
        //this.transform.DOScale(objectScale, scaleTimer);  //���[�v���Ȃ����
        this.transform.DOScale(objectScale, scaleTimer).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
        //Debug.Log("CommandScale Active");
    }

    //�R�}���h���o�E���h�ړ������鏈��
    void CommandJump()
    {
        //this.transform.DOJump(targetPosition, jumpPower, numJump, duration);  //���[�v���Ȃ����
        this.transform.DOJump(targetPosition, jumpPower, numJump, duration).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
        //Debug.Log("CommandJump Active");
    }

    //�R�}���h���w�肵���ʒu���ړ������鏈��
    void CommandPath()
    {
        //this.transform.DOPath(path, duration);  //���[�v���Ȃ����
        this.transform.DOPath(path, duration).SetLoops(-1, LoopType.Restart).SetEase(ease);
        //Debug.Log("CommandPath Active");
    }

    //�R�}���h�̐F��ς��鏈��
    void CommandColor()
    {
        //this.rendererComponent.material.DOColor(Color.red, colorTimer); //���[�v���Ȃ����
        this.rendererComponent.material.DOColor(Color.red, colorTimer).SetLoops(-1,LoopType.Yoyo).SetEase(ease);
        //Debug.Log("CommandColor Active");
    }

    //�R�}���h�̃A���t�@�l��ω������鏈���i�������j
    void CommandFade()
    {
        //Debug.Log("CommandFade Active");
    }
}
