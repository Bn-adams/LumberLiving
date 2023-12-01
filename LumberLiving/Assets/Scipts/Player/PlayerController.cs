using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Movement Variables
    private Rigidbody rb;
    private PlayerStats stats;
    private float ms;
    private Vector3 moveDirection;
    public Transform orientation;
    //Stamina Variables
    private float waitTime = 0.5f;
    public Image staminaBar;
    public Slider slider;
    public bool isAttacking=false;
    public float attackCost = 1;
    public bool isPressed = false;
    
    
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        
        if (stats != null)
        {
            ms = stats.Speed;
            stats.MaxStamina = 100;
            stats.StaminaCount = 100;
        }
       
        

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Chopping();
       

        //rb.velocity = new Vector3(horizontalInput * MS, rb.velocity.y, verticalInput * MS );
        //Vector3 Movement = new Vector3(horizontalInput * MS, 0f, verticalInput * MS);
        //transform.Translate(Movement);
        Debug.Log(staminaBar.fillAmount);
    }
    //Controls the player movement and get inputs 
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
    //Calls the chop logic when right input is pressed and has enough stam 
    public void Chopping()
    {
        if (Input.GetMouseButton(0) && !isPressed && stats.StaminaCount > 0)
        {

            isAttacking = true;
            StartCoroutine(Chop());


        }
    }
    // stam adjustments made here for chop 
    public IEnumerator Chop()
    {
        isPressed = true;
        yield return new WaitForSeconds(waitTime);

        isAttacking = false;
        Debug.Log("Attack");

        stats.StaminaCount -= attackCost;
        if (stats.StaminaCount < 0) stats.StaminaCount = 0;

        staminaBar.fillAmount = stats.StaminaCount / stats.MaxStamina;



        slider.value = staminaBar.fillAmount;
        isPressed = false;
    }
   
    
    


}   












