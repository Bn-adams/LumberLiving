using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerStats stats;
    private int horizontalInput;
    private int verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stats = GetComponent<PlayerStats>();    
    }

    // Update is called once per frame
    void Update()
    {
        Input.GetAxisRaw("Horizontal");
        Input.GetAxisRaw("Vertical");
       
       
    }
}
