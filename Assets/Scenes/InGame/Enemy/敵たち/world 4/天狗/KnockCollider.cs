using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockCollider : MonoBehaviour
{
    private LifeManager lifeManager;
    private PlayerManager playerManager;
    public AudioClip BeatingSound;
    private AudioSource audioSource;

    private void Start()
    {
        GameObject lifeManagerObject = GameObject.Find("Life");
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        GameObject playerManagerObject = GameObject.Find("Player");
        playerManager = playerManagerObject.GetComponent<PlayerManager>();

        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lifeManager.GetDamage(1);
            if(playerManager.isHaveCommand == true)
            {
                playerManager.Throw();
            }
            //Debug.Log("1damage");
            audioSource.PlayOneShot(BeatingSound);  // ƒTƒEƒ“ƒh‚ð–Â‚ç‚·
        }
        else
        {
            audioSource.PlayOneShot(BeatingSound);
        }

    }
}
