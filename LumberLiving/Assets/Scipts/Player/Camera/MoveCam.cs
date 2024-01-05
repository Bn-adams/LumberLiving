using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform cameraPosition;
   

    // Update is called once per frame
    //places the camera in the camera holder 
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
