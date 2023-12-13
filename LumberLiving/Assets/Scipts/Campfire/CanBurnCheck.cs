using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanBurnCheck : MonoBehaviour
{
    
    PlayerStats playerStats;
   

    // Start is called before the first frame update
    void Start()
    {
         
        
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }
    //show press f to burn when in zone 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BurnZone")
        {
            //burnText.enabled = true; 
            
            playerStats.CanBurnWood = true;
        }
    }
    // removes press f to burn when in zone 

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BurnZone")
        {
            //burnText.enabled = false;
            playerStats.CanBurnWood = false;
        }
        

    }
}
