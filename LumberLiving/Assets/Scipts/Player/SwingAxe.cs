using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class SwingAxe : MonoBehaviour
{

    public Animator AxeSwing;
    private bool hasHit = false;
    PlayerStats stats;

    void Start()
    {
        AxeSwing = GetComponent<Animator>();
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();

    }
    void Update()
    {
        SwingCheck();
    }

    private void SwingCheck()
    {
        if (AxeSwing != null)
        {
            if (stats.StaminaCount > stats.AttackCost)
            {
                if (Input.GetMouseButton(0))
                {
                    AxeSwing.SetTrigger("TrAttack");
                    hasHit = true;

                }
                if (Input.GetMouseButton(0) && hasHit)
                {
                    AxeSwing.SetTrigger("TrB");
                    hasHit = false;
                }
            }
        }
    }
}

    
        
    

