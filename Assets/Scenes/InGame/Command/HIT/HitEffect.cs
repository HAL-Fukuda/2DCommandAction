using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    private ParticleSystem hitParticle;
   
    void Start()
    {
        hitParticle = this.GetComponent<ParticleSystem>();
    }

    
    void FixedUpdate()
    {
        if (hitParticle.isStopped)
        {
            Destroy(this.gameObject);
        }
    }
}
