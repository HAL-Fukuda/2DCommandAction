using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstSelected : MonoBehaviour
{
    public GameObject firstSelectedObject;
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstSelectedObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
