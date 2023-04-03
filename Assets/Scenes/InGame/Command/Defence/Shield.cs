using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private GameObject player;

    // Update is called once per frame
    void FixedUpdate()
    {
        player = GameObject.Find("Player");
        Vector3 pos = player.transform.position;
        pos += new Vector3(0, 1, 0);
        this.transform.position = pos;
    }
}
