using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewClass : MonoBehaviour
{
    void OnEnable()
    {
        EventClass.dawn += DawnLight;
    }

    void OnDisable()
    {
        EventClass.dawn -= DawnLight;
    }

    void DawnLight() 
    {
        //Perform some function
        //create a betting pool
        //write blog post
        //write team/player critique
        Debug.Log("Yeah, baby!");
    }
}
