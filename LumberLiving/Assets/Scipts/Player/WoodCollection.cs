using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WoodCollection : MonoBehaviour
{
    private PlayerStats playerStats;

    [SerializeField] private TextMeshProUGUI WoodText;
    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }
    public void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.CompareTag("Wood"))
        {
            Destroy(other.gameObject);
            if (playerStats != null)
            {
                playerStats.WoodCount++;
                WoodText.text = "Wood: "+ playerStats.WoodCount;
            }


        }
    }
}