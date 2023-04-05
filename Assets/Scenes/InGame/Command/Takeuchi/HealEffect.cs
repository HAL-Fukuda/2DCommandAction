using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : MonoBehaviour
{
    private GameObject player;
    ParticleSystem healParticle;

    void Start()
    {
        healParticle = this.GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        player = GameObject.Find("Player");
        Vector3 pos = player.transform.position;
        pos += new Vector3(0, 0, 0);
        this.transform.position = pos;

        if (healParticle.isStopped)
        {
            Destroy(this.gameObject);
        }
    }
}
