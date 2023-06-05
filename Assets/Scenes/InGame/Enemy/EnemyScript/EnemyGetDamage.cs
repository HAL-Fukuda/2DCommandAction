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

    [SerializeField][Header("�t�F�[�h�C���A�A�E�g�p")]
    float fadeInSpeed = 0.01f;    //�t�F�[�h�C���X�s�[�h
    float fadeOutSpeed = 0.005f;  //�t�F�[�h�A�E�g�X�s�[�h
    float red, green, blue, alfa;  //Material�̐F
    public Renderer fadeMaterial;  //Material�ɃA�N�Z�X���邽�߂̗e��
    public bool isFadeOut = false;  //�t�F�[�h�A�E�g��Ԃ̊Ǘ�
    public bool isFadeIn = true;   //�t�F�[�h�C����Ԃ̊Ǘ�

    [SerializeField][Header("�G�t�F�N�g�p")]
    public bool killFlag = false;  //���S���G�t�F�N�g�p
    public bool hitFlag = false;  //�q�b�g�G�t�F�N�g�p
    [SerializeField] private GameObject hitEffectPrefab;  //�q�b�g�G�t�F�N�g�p
    [SerializeField] private GameObject destroyEffectPrefab;  //���S���G�t�F�N�g�p
    [SerializeField] private GameObject rangeAPrefab;  //�G���S���G�t�F�N�g�����͈�A
    [SerializeField] private GameObject rangeBPrefab;  //�G���S���G�t�F�N�g�����͈�B
    public float hitTime;  //�q�b�g�G�t�F�N�g�𐶐����鎞��
    private float spawnTime;  //�G���S���G�t�F�N�g�p
    private GameObject effectSpawnPos;  //�G�t�F�N�g�����̊�̈ʒu
    private GameObject rangeA;  //RangeA�̈ʒu
    private GameObject rangeB;  //RangeB�̈ʒu

    
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

        //�G�t�F�N�g�𐶐�����ʒu���擾
        effectSpawnPos = GameObject.Find("EnemySpawnPoint");

        //�G���S���G�t�F�N�g�����͈͂𐶐�
        EffectRangeSpawn();

        //�G���S���G�t�F�N�g�����͈͂��擾
        rangeA = GameObject.Find("DestroyEffectRangeA(Clone)");
        rangeB = GameObject.Find("DestroyEffectRangeB(Clone)");
    }

    //���ʂ̃R�}���h�̃_���[�W
    public void GetDamage()
    {
        GetDamageInitialize();

        // �J������h�炷
        CameraEffect cameraScript = GameObject.Find("Main Camera").GetComponent<CameraEffect>();
        cameraScript.ShakeCamera(0.2f, 0.2f);

        // �U�����ꂽ���̈ʒu���擾����
        originalPosition = transform.position;

        hitFlag = true;

        // HP��1���炷
        hp--;

        // HP��0�ɂȂ�����폜����
        if (hp <= 0)
        {
            GameMgr.Instance.DeleteEnemy();

            isFadeOut = true;
            killFlag = true;
        }

        // ���b�㌳�̐F�ɖ߂�
        StartCoroutine(ChangeAndResetColor(ColorDuration));
        // �U��������
        StartCoroutine(ShakeCoroutine());
    }

    //�f�J�R�}���h�̃_���[�W
    public void GetBigDamage()
    {
        GetDamageInitialize();

        // �J������h�炷
        CameraEffect cameraScript = GameObject.Find("Main Camera").GetComponent<CameraEffect>();
        cameraScript.ShakeCamera(0.2f, 0.2f);

        // �U�����ꂽ���̈ʒu���擾����
        originalPosition = transform.position;

        hitFlag = true;

        // HP��1���炷
        hp -= 2;

        // HP��0�ɂȂ�����폜����
        if (hp <= 0)
        {
            GameMgr.Instance.DeleteEnemy();

            isFadeOut = true;
            killFlag = true;
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

    //�t�F�[�h�C��
    public void FadeIn()
    {
        fadeMaterial.enabled = true;
        alfa += fadeInSpeed;
        SetAlfa();
        
        if (alfa >= 1)
        {
            isFadeIn = false;
        }
    }

    //�t�F�[�h�A�E�g
    public void FadeOut()
    {
        alfa -= fadeOutSpeed;
        SetAlfa();
        
        if (alfa <= 0)
        {
            isFadeOut = false;
            fadeMaterial.enabled = false;
            killFlag = false;
            GameMgr.Instance.DeathFlagChenge();

            Destroy(this.gameObject);
        }
    }

    //�t�F�[�h�C���A�A�E�g�p���l�Z�b�g
    public void SetAlfa()
    {
        fadeMaterial.material.color = new Color(red, green, blue, alfa);
    }

    //�G�t�F�N�g�����͈͐���
    public void EffectRangeSpawn()
    {
        //RangeA
        float Ax = effectSpawnPos.transform.position.x - 1;
        float Ay = effectSpawnPos.transform.position.y + 1;
        float Az = effectSpawnPos.transform.position.z;

        Instantiate(rangeAPrefab, new Vector3(Ax, Ay, Az), rangeAPrefab.transform.rotation);

        //RangeB
        float Bx = effectSpawnPos.transform.position.x + 1;
        float By = effectSpawnPos.transform.position.y - 1;
        float Bz = effectSpawnPos.transform.position.z;

        Instantiate(rangeBPrefab, new Vector3(Bx, By, Bz), rangeBPrefab.transform.rotation);
    }

    //�G���S���G�t�F�N�g����
    public void DestroyEffectSpawn()
    {
        spawnTime = spawnTime + Time.deltaTime;

        if (spawnTime > 0.1f)
        {
            float x = Random.Range(rangeA.transform.position.x, rangeB.transform.position.x);
            float y = Random.Range(rangeA.transform.position.y, rangeB.transform.position.y);
            float z = Random.Range(rangeA.transform.position.z, rangeB.transform.position.z);

            Instantiate(destroyEffectPrefab, new Vector3(x, y, z), destroyEffectPrefab.transform.rotation);
            spawnTime = 0f;
        }
    }

    //�q�b�g�G�t�F�N�g����
    public void GetDamegeEffectSpawn()
    {
        spawnTime = spawnTime + Time.deltaTime;
        
        if (spawnTime > 0.1f)
        {
            float x = Random.Range(rangeAPrefab.transform.position.x, rangeBPrefab.transform.position.x);
            float y = Random.Range(rangeAPrefab.transform.position.y, rangeBPrefab.transform.position.y);
            float z = Random.Range(rangeAPrefab.transform.position.z, rangeBPrefab.transform.position.z);

            Instantiate(hitEffectPrefab, new Vector3(x, y, z), hitEffectPrefab.transform.rotation);
            spawnTime = 0f;
        }
    }
}
