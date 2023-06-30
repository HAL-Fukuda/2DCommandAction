using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSE : MonoBehaviour
{
    public AudioClip highlightSound; // �Đ�����SE�̃I�[�f�B�I�N���b�v
    public AudioClip pushSound; // �{�^�����������Ƃ���SE�̃I�[�f�B�I�N���b�v
    private Button button; // �{�^���R���|�[�l���g
    private bool hasPlayedHighlightSound; // SE���Đ����ꂽ���ǂ����̃t���O
    private AudioSource audioSource; // �I�[�f�B�I�\�[�X

    private void Start()
    {
        button = GetComponent<Button>();
        hasPlayedHighlightSound = false;

        // �I�[�f�B�I�\�[�X��ǉ�
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        // �{�^����Highlighted��ԂɂȂ�����SE���Đ�
        if (button != null && button.interactable && !hasPlayedHighlightSound && IsButtonHighlighted())
        {
            PlayHighlightSound();
            hasPlayedHighlightSound = true;
        }
        else if (!IsButtonHighlighted())
        {
            hasPlayedHighlightSound = false;
        }
    }

    private bool IsButtonHighlighted()
    {
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;
        return selectedObject != null && selectedObject == button.gameObject;
    }

    private void PlayHighlightSound()
    {
        audioSource.PlayOneShot(highlightSound);
    }

    public void PlayPushSound()
    {
        audioSource.PlayOneShot(pushSound);
    }

    public void PlayPushSoundAndDestroy()
    {
        // SE�Đ��p�̃I�u�W�F�N�g�𐶐�
        GameObject soundObject = new GameObject("PushSoundObject");
        AudioSource soundSource = soundObject.AddComponent<AudioSource>();

        // �{�^������SE���Đ�
        soundSource.PlayOneShot(pushSound);

        // �Đ��I����ɃI�u�W�F�N�g��j��
        Destroy(soundObject, pushSound.length);
    }
}
