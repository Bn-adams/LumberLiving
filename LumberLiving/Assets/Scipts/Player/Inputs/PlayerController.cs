using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

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
    public bool isPressed = false;

    //Campfire Variables
    
    [SerializeField] public TextMeshProUGUI WoodText;
    private float WoodBurnAmount = 10;
    private GameStats gStats;
    public bool isBuring = false;

   

    //Menu
    PlayerCam cam;

    //Building Varibles
    public Vector3 playerPos;
    public float buildStamCost = 5;
    public int buildCost = 5;
    public GameObject CampPreFab;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        gStats = GameObject.Find("GameSystems").GetComponent<GameStats>();
        
        //sets the player stats if they are incuded in the player class
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

        BurnWood();

        UseMouse();

        playerPos = transform.position;

        Building();

        

        Debug.Log(staminaBar.fillAmount);
    }


    //Controls the player movement and get inputs 
    public void Movement()
    {
        //gets the input here 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 || verticalInput != 0)
        {
            if(stats.StaminaCount > 0)// checks for 0 stam
            {
                moveDirection = orientation.right * horizontalInput + orientation.forward * verticalInput;
                rb.velocity = (moveDirection * ms);
                //StartCoroutine(WalkStamDelay());

                stats.StaminaCount -= stats.WalkCost * Time.deltaTime;//applies the stam cost once a second.
                if (stats.StaminaCount < stats.MinStamina) stats.StaminaCount = stats.MinStamina;

                staminaBar.fillAmount = stats.StaminaCount / stats.MaxStamina;

                slider.value = staminaBar.fillAmount;
                //caculates and fills the stam bar
            }
            


        }
        
    }


    //Calls the chop logic when right input is pressed and has enough stam 
    public void Chopping()
    {
        if (Input.GetMouseButton(0) && !isPressed && stats.StaminaCount > stats.AttackCost) // checks the player can chop and isnt already amd had enough stam
        {
            
            isAttacking = true;
            StartCoroutine(Chop());
            //calls the chop logic 

        }
    }

    public IEnumerator Chop()
    {
        isPressed = true;
        yield return new WaitForSeconds(waitTime);// delay for animations

        isAttacking = false;
        Debug.Log("Attack");

        // stam adjustments made here for chop 
        stats.StaminaCount -= stats.AttackCost;
        if (stats.StaminaCount < stats.MinStamina) stats.StaminaCount = stats.MinStamina;

        staminaBar.fillAmount = stats.StaminaCount / stats.MaxStamina;
        slider.value = staminaBar.fillAmount;

        isPressed = false;
    }

    public void BurnWood()
    {
        if(stats != null)
        {
            if (Input.GetKey(KeyCode.F) && stats.CanBurnWood&&!isBuring&&stats.WoodCount != 0 ) // checks player has wood and is pressing to feed fire 
            {
                
                isBuring = true;
                StartCoroutine(BurnWoodDelay());//starts delay on the logic to match up with the ani 

            }
        } 
    }

   public IEnumerator BurnWoodDelay()
   {
        //logic for the burning of the wood 
        yield return new WaitForSeconds(2);
      
        stats.WoodCount--;
        WoodText.text = "Wood: " + stats.WoodCount;
        //adjusts the wood amount.
        isBuring = false;
       // adds stam here once has been burnt
        stats.StaminaCount = WoodBurnAmount + stats.StaminaCount;
        if (stats.StaminaCount > stats.MaxStamina) stats.StaminaCount = stats.MaxStamina;
        staminaBar.fillAmount = stats.StaminaCount / stats.MaxStamina;
        slider.value = staminaBar.fillAmount;
        //Adjusts the timer
        if (gStats != null) gStats.GameClockCurrent = gStats.GameClockCurrent + 2;

   }

    public void UseMouse()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            //unlocks and shows the cursor for the pause menu 
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
            
        }
    }
    public void Building()
    {
        if (stats != null)
        {
            if (Input.GetKeyUp(KeyCode.B) && stats.WoodCount > 4 && stats.StaminaCount > buildStamCost) //does all the build checks for the building
            {
                playerPos = transform.position;//gets a updates player position 
                //playerRotation = transform.rotation;
                Vector3 buildPos = new Vector3(playerPos.x + 5 , playerPos.y-1, playerPos.z); // genrates a vector 3 for the spawn position
                //Debug.Log(buildPos);
                GameObject newCampfire = Instantiate(CampPreFab);
                newCampfire.transform.position = buildPos;
                //adjusts the Wood Amount after building 
                stats.WoodCount -= buildCost;
                WoodText.text = "Wood: " + stats.WoodCount;


                //adjusting the stamina after building
                stats.StaminaCount -= buildStamCost;
                if (stats.StaminaCount < stats.MinStamina) stats.StaminaCount = stats.MinStamina;

                staminaBar.fillAmount = stats.StaminaCount / stats.MaxStamina;



                slider.value = staminaBar.fillAmount;
            }
        }
    }



}   












