using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockCollider : MonoBehaviour
{
    private LifeManager lifeManager;
    private PlayerManager playerManager;
    public AudioClip BeatingSound;

    private void Start()
    {
        GameObject lifeManagerObject = GameObject.Find("Life");
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();

        GameObject playerManagerObject = GameObject.Find("Player");
        playerManager = playerManagerObject.GetComponent<PlayerManager>();
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
            AudioSource.PlayClipAtPoint(BeatingSound, new Vector3(0, 2, -10));
        }
        else
        {
            AudioSource.PlayClipAtPoint(BeatingSound, new Vector3(0, 2, -10));
        }

    }
}
