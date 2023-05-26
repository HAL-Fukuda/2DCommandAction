using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  //DOTween���g���̂ɕK�v

public partial class Command : MonoBehaviour
{
    Renderer rendererComponent;  //RendererComponent���擾
    Vector3  targetPosition = new Vector3(1, 0, 0); //�ړ���̍��W
    Vector3  objectScale = new Vector3(1, 1, 1);  //�ω���̃T�C�Y
    Ease     ease = Ease.Linear;  //�n�_�ƏI�_�̂Ȃ���

    float duration = 1;    //�ړ��Ɋ|���鎞��
    float scaleTimer = 1;  //�g��E�k���܂ł̎���
    float jumpPower = 1;   //�o�E���h�̍���
    int   numJump = 1;     //�o�E���h�̉�
    float colorTimer = 1;  //�F���ς��܂ł̎���
    float alpha = 1;       //�t�F�[�h��̃A���t�@�l 
    float alphaTimer = 1;  //�t�F�[�h�Ɋ|���鎞��

    public enum eCommandStat
    {
        Move,
        Rotate,
        Scale,
        Jump,
        Path,
        Color,
        Fade
    }

    private eCommandStat commandStat;

    Vector3[] path =
    {
        new Vector3(5,0.2349713f,0),
        new Vector3(5,3,0),
        new Vector3(10.46641f,3,0),
        new Vector3(10.46641f,0.2349713f,0)
    };

    void CommandOperatorInitialize()
    {
        switch (commandStat) 
        {
            case eCommandStat.Move:
                CommandMove();
                break;
            case eCommandStat.Rotate:
                CommandRotate();
                break;
            case eCommandStat.Scale:
                CommandScale();
                break;
            case eCommandStat.Jump:
                CommandJump();
                break;
            case eCommandStat.Path:
                CommandPath();
                break;
            case eCommandStat.Color:
                CommandColor();
                break;
            case eCommandStat.Fade:
                CommandFade();
                break;
            default:
                break;
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
