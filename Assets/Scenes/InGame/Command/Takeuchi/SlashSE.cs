using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashSE : MonoBehaviour
{
    AudioSource slashSE;
    private bool isSlashSoundEnd;
    
    void Start()
    {
        slashSE = this.GetComponent<AudioSource>();

        slashSE.Play();

        isSlashSoundEnd = true;
    }

    
    void FixedUpdate()
    {
        if (isSlashSoundEnd)
        {
            SlashSEDestroy();
        }
    }

    void SlashSEDestroy()
    {
        StartCoroutine(SlashDestroy());
    }

    IEnumerator SlashDestroy()
    {
        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
    }
}
