using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shout : MonoBehaviour
{
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        // ƒJƒƒ‰‚ğ—h‚ç‚·
        CameraEffect cameraScript = GameObject.Find("Main Camera").GetComponent<CameraEffect>();
        cameraScript.ShakeCamera(0.2f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer> 2.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
