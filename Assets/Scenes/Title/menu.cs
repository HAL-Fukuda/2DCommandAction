using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    Button start;
    Button setting;
    Button exit;

    // Start is called before the first frame update
    void Start()
    {
        start = GameObject.Find("gamestart").GetComponent<Button>();
        setting = GameObject.Find("setting").GetComponent<Button>();
        exit = GameObject.Find("exit").GetComponent<Button>();

        start.Select();
    }
}
