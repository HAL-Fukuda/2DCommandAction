using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVACollision : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("syoutoru");
        Destroy(this.gameObject);
    }
}
