using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class STAGE_CLEAR : MonoBehaviour
{
    [SerializeField] private GameObject prefab_FINISH;
    [SerializeField] private GameObject prefab_STAGECLEAR;

    public float dropSpeed = 1.0f;
    public Vector2 drawPosition;

    void Start()
    {
        // ��ʏ�ɔz�u
        prefab_FINISH.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 700);
        prefab_FINISH.SetActive(true);

        // ��ʒ��S�ɗ����Ă���
        prefab_FINISH.GetComponent<RectTransform>().DOAnchorPos(drawPosition, dropSpeed).SetEase(Ease.InQuad).OnComplete(() =>
        {
            // �������I�������P�b��ɉ�ʏ�ɖ߂�
            prefab_FINISH.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 700), dropSpeed).SetDelay(1f).OnComplete(() =>
            {
                // ��ʏ�ɔz�u
                prefab_STAGECLEAR.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 700);
                prefab_STAGECLEAR.SetActive(true);

                // ��ʒ��S�ɗ����Ă���
                prefab_STAGECLEAR.GetComponent<RectTransform>().DOAnchorPos(drawPosition, dropSpeed).SetEase(Ease.InQuad).OnComplete(() =>
                {
                    // �������I�������P�b��ɉ�ʏ�ɖ߂�
                    prefab_STAGECLEAR.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 700), dropSpeed).SetDelay(1f).OnComplete(() =>
                    {
                        // �I�u�W�F�N�g�폜
                        Destroy(gameObject);
                        // �X�e�[�W�Z���N�g��ʂ�
                        SceneManager.LoadScene("StageSelect");
                    });
                });
            });
        });
    }
}
