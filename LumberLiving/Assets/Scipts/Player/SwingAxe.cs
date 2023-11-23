using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingAxe : MonoBehaviour
{
    public GameObject axeHolder;
    
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            axeHolder.GetComponent<Animator>().Play("BaseLayer.Take 001");
        }
       
    }
}
