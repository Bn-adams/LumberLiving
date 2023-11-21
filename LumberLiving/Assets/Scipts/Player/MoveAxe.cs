using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveAxe : MonoBehaviour
{
    public Transform axePosition;
    
 
    

    // Update is called once per frame
    void Update()
    {
        transform.position = axePosition.position ;
    }
}

