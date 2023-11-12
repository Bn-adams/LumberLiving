using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerStats stats;
    private float ms;
    
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        ms = stats.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(horizontalInput != 0 || verticalInput != 0)
        {
            rb.velocity = new Vector3(horizontalInput*ms,rb.velocity.y,verticalInput*ms);
            
        }
      
     
        //rb.velocity = new Vector3(horizontalInput * MS, rb.velocity.y, verticalInput * MS );
        //Vector3 Movement = new Vector3(horizontalInput * MS, 0f, verticalInput * MS);
        //transform.Translate(Movement);


    }
}
