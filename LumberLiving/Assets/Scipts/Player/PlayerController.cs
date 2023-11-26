using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerStats stats;
    private float ms;
    private Vector3 moveDirection;
    public Transform orientation;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        if (stats != null)
        {
            ms = stats.Speed;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        //rb.velocity = new Vector3(horizontalInput * MS, rb.velocity.y, verticalInput * MS );
        //Vector3 Movement = new Vector3(horizontalInput * MS, 0f, verticalInput * MS);
        //transform.Translate(Movement);
    }
    public void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 || verticalInput != 0)
        {
            moveDirection = orientation.right * horizontalInput + orientation.forward * verticalInput;
            rb.velocity = (moveDirection * ms);

        }
    }


}   












