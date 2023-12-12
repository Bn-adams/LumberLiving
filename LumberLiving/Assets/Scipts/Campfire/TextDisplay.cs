using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    [SerializeField] public GameObject text;
    PlayerStats playerStats;
    

    // Start is called before the first frame update
    void Start()
    {
        
        text.SetActive(false);
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }
    //show press f to burn when in zone 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            text.SetActive(true);
            playerStats.CanBurnWood = true;
        }
    }
    // removes press f to burn when in zone 

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            text.SetActive(false);
            playerStats.CanBurnWood = false;
        }
    }
}
