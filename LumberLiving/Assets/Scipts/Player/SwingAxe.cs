using UnityEngine;

public class SwingAxe : MonoBehaviour
{
    
    private Animator AxeSwing;


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
                AxeSwing.SetTrigger("TrA");
                
            }
            else
            {
                AxeSwing.SetTrigger("TrB");
                AxeSwing.SetTrigger("TrI");
            }
            

        }

       // if (Input.GetMouseButtonDown(0))
        {
         //   axeHolder.GetComponent<Animator>().Play("BaseLayer.Take 001");
        }
       
    }
}
