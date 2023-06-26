using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSE : MonoBehaviour
{
    public AudioClip highlightSound; // 再生するSEのオーディオクリップ
    public AudioClip pushSound; // ボタンを押したときのSEのオーディオクリップ
    private Button button; // ボタンコンポーネント
    private bool hasPlayedHighlightSound; // SEが再生されたかどうかのフラグ
    private AudioSource audioSource; // オーディオソース

    private void Start()
    {
        button = GetComponent<Button>();
        hasPlayedHighlightSound = false;

        // オーディオソースを追加
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        // ボタンがHighlighted状態になったらSEを再生
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
        Debug.Log("PUSH");
    }
}
