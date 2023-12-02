using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    public GameObject text;
    PlayerStats playerStats;
    [SerializeField] private TextMeshProUGUI WoodText;

    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            text.SetActive(true);
            playerStats.CanBurnWood = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            text.SetActive(false);
            playerStats.CanBurnWood = false;
        }
    }
}
