using System.Collections;
using UnityEngine;

public class SwingAxe : MonoBehaviour
{
    
    public Animator AxeSwing;
    private bool hasHit=false;

    void Start()
    {
        AxeSwing = GetComponent<Animator>();
        
    }
    void Update()
    {
        

        if (AxeSwing != null)
        {
            if(Input.GetMouseButton(0))
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
       

        // if (Input.GetMouseButtonDown(0))
        {
         //   axeHolder.GetComponent<Animator>().Play("BaseLayer.Take 001");
        }
       
    }
}
