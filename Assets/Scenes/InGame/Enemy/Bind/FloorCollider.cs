using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{
    void Start()
    {
        Invoke("FloorHide", 5f);
    }

    void FloorHide()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager playerManager = other.GetComponent<PlayerManager>();
            playerManager.moveSpeed /= 2f;
            Invoke("FloorHide", 5f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager playerManager = other.GetComponent<PlayerManager>();
            playerManager.moveSpeed *= 2f;
        }
    }
}
