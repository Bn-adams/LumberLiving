using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerStats stats;
    private float MS;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        stats.Speed = MS;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(horizontalInput * MS, 0f, verticalInput * MS);
        transform.Translate(Movement);
       
       
    }
}
