using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetDamage : MonoBehaviour
{
    private Material material; // �}�e���A��
    private Color originalColor; // ���̐F

    public float ColorDuration = 0.1f; // �Ԃ��Ȃ鎞��

    private Vector3 originalPosition; // �U���O�̍��W

    public float shakeIntensity = 0.1f; // �h��̋���
    public float shakeDuration = 0.2f; // �h��鎞��

    private int hp = 3; // HP�̏����l

    // �����������B�K��Start()�ŌĂяo�����ƁB
    public void GetDamageInitialize()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        material = renderer.material;
        originalColor = material.color;
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
            Destroy(gameObject);
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
}
