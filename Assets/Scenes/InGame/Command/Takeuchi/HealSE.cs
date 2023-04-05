using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSE : MonoBehaviour
{
    AudioSource healSE;
    private bool isHealSoundEnd;

    void Start()
    {
        healSE = this.GetComponent<AudioSource>();

        healSE.Play();

        isHealSoundEnd = true;
    }

    
    void FixedUpdate()
    {
        StartCoroutine(HealDestroy());
    }

    IEnumerator HealDestroy()
    {
        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
    }
}
