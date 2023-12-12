using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class BurnWood : MonoBehaviour
{
    public Animator Burn;
    private bool hasAdded = false;
    PlayerStats playerStats;
    
    // Start is called before the first frame update
    void Start()
    {
        Burn = GetComponent<Animator>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        
    }
   

    // Update is called once per frame
    void Update()
    {
        BurnCheck();
    }

    //checks that the player has wood and is near then sets ani triggers if input detected 
    private void BurnCheck()
    {
        if (Burn != null)
        {
            if (playerStats.WoodCount != 0)
            {
                if (playerStats.CanBurnWood == true)
                {
                    if (Input.GetKey(KeyCode.F))
                    {
                        Burn.SetTrigger("TrAdd");
                        hasAdded = true;
                    }
                    if (Input.GetKey(KeyCode.F))
                    {
                        Burn.SetTrigger("TrBack");
                        hasAdded = false;
                    }
                }
            }


        }
    }
}
