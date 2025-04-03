using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Research_UI : MonoBehaviour
{
    public GameObject UI;


    void Start()
    {
        UI.SetActive(false);
    }

    void OnTriggerEnter(Collider Obj)
    {
        if(Obj.tag == "MainCamera") // Check if camera has this tag
        {
            UI.SetActive(true);
        }
    }


    void OnTriggerExit(Collider Obj)
    {
        if (Obj.tag == "MainCamera")
        {
            UI.SetActive(false);
        }
    }
}
