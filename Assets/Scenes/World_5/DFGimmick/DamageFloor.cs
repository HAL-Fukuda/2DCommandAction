using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFloor : MonoBehaviour
{
    private LifeManager lifeManager;
    private BoxCollider2D boxCollider;
    private float timer = 0f;
    private bool isColliding = false;

   // public AudioClip se;

    void Start()
    {
        GameObject lifeManagerObject = GameObject.Find("Life");
        lifeManager = lifeManagerObject.GetComponent<LifeManager>();
        boxCollider = this.GetComponent<BoxCollider2D>();
    }

    public void ToggleCollider(bool enabled)
    {
        boxCollider.enabled = enabled;
    }

    private void Update()
    {
        if (isColliding)
        {
            timer += Time.deltaTime;

            if (timer >= 3f)
            {
                lifeManager.GetDamage(1);
                timer = 0f;
                //AudioSource.PlayClipAtPoint(se, transform.position);
            }
        }
        else
        {
            timer = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = false;
        }
    }
}
