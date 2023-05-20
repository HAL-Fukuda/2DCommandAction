using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] LaserPoint laserPoint;
    public AudioClip FireSE;
    

    public void ObjectOn()
    {
        // SE�Đ�
        AudioSource.PlayClipAtPoint(FireSE, transform.position);

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
            Debug.Log("�������Ă���");
        }
    }
}
