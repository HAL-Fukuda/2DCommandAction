using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    private Material material; // �}�e���A��
    private Color originalColor; // ���̐F
    private Vector3 originalPosition; // �U���O�̍��W

    public float ColorDuration = 0.1f; // �Ԃ��Ȃ鎞��
    public float shakeIntensity = 0.1f; // �h��̋���
    public float shakeDuration = 0.2f; // �h��鎞��

    float fadeSpeed = 0.01f;  //�����x���ς��X�s�[�h
    float red, green, blue, alfa;  //Material�̐F

    public bool isFadeOut = false;  //�t�F�[�h�A�E�g��Ԃ̊Ǘ�
    public bool isFadeIn = false;   //�t�F�[�h�C����Ԃ̊Ǘ�

    public Renderer fadeMaterial;  //Material�ɃA�N�Z�X���邽�߂̗e��

    // �����������B�K��Start()�ŌĂяo�����ƁB
    public void GetDamageInitialize()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        material = renderer.material;
        originalColor = material.color;

        fadeMaterial = GetComponent<Renderer>();
        red = fadeMaterial.material.color.r;
        green = fadeMaterial.material.color.g;
        blue = fadeMaterial.material.color.b;
        alfa = fadeMaterial.material.color.a;
    }

    public void GetDamage()
    {
        GetDamageInitialize();

        // �U�����ꂽ���̈ʒu���擾����
        originalPosition = transform.position;

        // HP��1���炷
        hp--;

        // HP��0�ɂȂ�����폜����
        if (hp <= 0)
        {
            GameMgr.Instance.DeleteEnemy();

            isFadeOut = true;

            if (isFadeOut)
            {
                StartFadeOut();
            }
        }

        // ���b�㌳�̐F�ɖ߂�
        StartCoroutine(ChangeAndResetColor(ColorDuration));
        // �U��������
        StartCoroutine(ShakeCoroutine());
    }

    public void GetBigDamage()
    {
        GetDamageInitialize();

        // �U�����ꂽ���̈ʒu���擾����
        originalPosition = transform.position;

        // HP��1���炷
        hp -= 2;

        // HP��0�ɂȂ�����폜����
        if (hp <= 0)
        {
            GameMgr.Instance.DeleteEnemy();

            isFadeOut = true;

            if (isFadeOut)
            {
                StartFadeOut();
            }
        }

        // ���b�㌳�̐F�ɖ߂�
        StartCoroutine(ChangeAndResetColor(ColorDuration));
        // �U��������
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ChangeAndResetColor(float delay)
    {
        // �ԐF�ɂ���
        ChangeColor(Color.red);
        // ��莞�Ԍ�ɐF��߂�
        yield return new WaitForSeconds(delay);
        ResetColor();
    }

    public void ChangeColor(Color newColor)
    {
        material.color = newColor;
    }

    public void ResetColor()
    {
        material.color = originalColor;
    }

    // �U��
    private IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // ���E�Ƀ����_���ɗh�炷
            Vector3 shakeAmount = new Vector3(Random.Range(-1f, 1f) * shakeIntensity, 0f, 0f);
            transform.position = originalPosition + shakeAmount;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // ���̈ʒu�ɖ߂�
        transform.position = originalPosition;
    }

    public void StartFadeOut()
    {
        alfa -= fadeSpeed;
        SetAlfa();

        if (alfa <= 0)
        {
            isFadeOut = false;
            fadeMaterial.enabled = false;

            Debug.Log(alfa);
            //Destroy(this.gameObject);
        }
    }

    public void SetAlfa()
    {
        fadeMaterial.material.color = new Color(red, green, blue, alfa);
    }
}
