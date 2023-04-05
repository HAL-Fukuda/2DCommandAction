using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSE : MonoBehaviour
{
    AudioSource commandSE;
    private bool isCommandSoundEnd;

    // Start is called before the first frame update
    void Start()
    {
        commandSE = this.GetComponent<AudioSource>();

        commandSE.Play();

        isCommandSoundEnd = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCommandSoundEnd)
        {
            CommandSEDestroy();
        }
    }

    void CommandSEDestroy()
    {
        StartCoroutine(CommandDestroy());
    }

    IEnumerator CommandDestroy()
    {
        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
    }
}
