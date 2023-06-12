using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarControl : MonoBehaviour
{
    public Slider slider;
    public Image barImage; // �o�[�̉摜
    public float speed = 0.1f; // �����X�s�[�h
    private bool isReady = false; // 100%���ǂ���

    public bool isFollowTarget;
    public Transform target;
    public Vector3 localPosition = new Vector3(0, 0, 0);

    private RectTransform uiElement;
    private RectTransform canvasRectTransform;

    public AudioClip FullSE;

    void Start()
    {
        if (isFollowTarget)
        {
            canvasRectTransform = this.transform.Find("Canvas") as RectTransform;
            uiElement = canvasRectTransform.transform.Find("Slider") as RectTransform;
        }
    }

    // �Ǐ]����
    void FixedUpdate()
    {
        if(isFollowTarget)
        {
            Vector3 worldPos = target.position + localPosition; // �Ǐ]����ʒu���w��
            Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos);
            Vector2 canvasPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPos, null, out canvasPos);

            uiElement.anchoredPosition = canvasPos;
        }
    }

    // �����������i�o�g���J�n���ɌĂяo���j
    public void ActionBarInitialize()
    {
        slider.value = 0.0f; // �o�[���̒l��0�ɂ���
        isReady = false; // ���������t���O��false�ɂ���
    }

    // �X�V����
    public void ActionBarUpdate()
    {
        // �A�N�V�����o�[��100�����ǂ���
        if (slider.value >= 1.0f)
        {
            if(isReady == false)
            {
                isReady = true;

                // 100���ɂȂ����^�C�~���O�ŃG�t�F�N�g����
                if (isReady)
                {
                    AudioSource.PlayClipAtPoint(FullSE,new Vector3(0,0,0)); // SE���Đ�
                    ChangeColor(Color.cyan); // �A�N�V�����o�[�̐F��ύX
                }
            }
        }

        // 100%����Ȃ���Βl�𑝉�������
        if (!isReady)
        {
            slider.value += speed / 100; // ���A�N�V�����o�[�̒l�� 100% = 1.0f �Ȃ̂�speed�̒l�����̂܂܁��ɂȂ�悤��
        }
    }

    // �A�N�V�����o�[����ɂ���
    public void SetEmpty()
    {
        isReady = false;
        slider.value = 0.0f; // 0���ɂ���
        ChangeColor(Color.yellow); // �o�[�����F�ɂ���
    }

    // isReady�̒l���擾
    public bool IsReady()
    {
        return isReady;
    }

    // �Q�[�W�̐F��ς���
    public void ChangeColor(Color color)
    {
        barImage.color = color;
    }
}
