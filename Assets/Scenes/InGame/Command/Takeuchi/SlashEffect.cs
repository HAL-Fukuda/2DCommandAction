using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEffect : MonoBehaviour
{
    ParticleSystem slashParticle;
    
    void Start()
    {
        slashParticle = this.GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        if (slashParticle.isStopped)
        {
            Destroy(this.gameObject);
        }
    }
}
