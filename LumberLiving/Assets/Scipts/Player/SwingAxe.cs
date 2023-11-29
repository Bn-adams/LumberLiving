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
            if(Input.GetKey(KeyCode.Space))
            {
                AxeSwing.SetTrigger("TrAttack");
                hasHit = true;

            }
            if (Input.GetKey(KeyCode.Space) && hasHit)
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
