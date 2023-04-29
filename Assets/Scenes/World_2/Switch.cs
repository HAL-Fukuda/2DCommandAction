using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public conveyor[] conveyorScripts;
    public elevator[] elevatorScripts;

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Command"))
        {
            foreach (var elevatorScript in elevatorScripts)
            {
                elevatorScript.isPaused = true;
            }

            foreach (var conveyorScript in conveyorScripts)
            {
                conveyorScript.ONOFFconveyor = false;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Command"))
        {
            foreach (var elevatorScript in elevatorScripts)
            {
                elevatorScript.isPaused = false;
            }

            foreach (var conveyorScript in conveyorScripts)
            {
                conveyorScript.ONOFFconveyor = true;
            }
        }
    }
}
