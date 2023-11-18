using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform cameraPosition;
   

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
