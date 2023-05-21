using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongLaser : MonoBehaviour
{
    [SerializeField] LongLaserPoint longlaserPoint;
    public AudioClip FireSE;

    private LifeManager lifeManager;

    void Start()
    {
        // SE�Đ�
        AudioSource.PlayClipAtPoint(FireSE, transform.position);

        // LifeManager�X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g���擾����
        GameObject lifeManagerObject = GameObject.Find("Life");

        // LifeManager�R���|�[�l���g���擾����
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
    }

    public void ObjectOn()
    {
        gameObject.SetActive(true);
    }

    public void ObjectOff()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
        }
    }
}
