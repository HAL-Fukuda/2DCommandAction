using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Conveyor conveyorScript;
    public Elevator elevatorScript;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Command")
        {
            elevatorScript.isPaused = true;
            conveyorScript.ONOFFconveyor = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Command")
        {
            elevatorScript.isPaused = false;
            conveyorScript.ONOFFconveyor = true;
        }
    }
}
