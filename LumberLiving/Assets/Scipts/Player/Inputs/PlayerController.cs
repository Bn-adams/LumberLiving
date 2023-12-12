using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public bool isPressed = false;

    //Campfire Variables
    private TextDisplay textDisplay;
    [SerializeField] private TextMeshProUGUI WoodText;
    public bool isBuring = false;
    private float WoodBurnAmount = 10;

    //Menu
    PlayerCam cam;

    //Building Varibles
    public Vector3 playerPos;
    public float buildCost = 5;
    public GameObject CampPreFab;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        textDisplay = GameObject.Find("Campfire").GetComponent<TextDisplay>();
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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 || verticalInput != 0)
        {
            if(stats.StaminaCount > 0)
            {
                moveDirection = orientation.right * horizontalInput + orientation.forward * verticalInput;
                rb.velocity = (moveDirection * ms);
                //StartCoroutine(WalkStamDelay());

                stats.StaminaCount -= stats.WalkCost * Time.deltaTime;
                if (stats.StaminaCount < stats.MinStamina) stats.StaminaCount = stats.MinStamina;

                staminaBar.fillAmount = stats.StaminaCount / stats.MaxStamina;

                slider.value = staminaBar.fillAmount;
            }
            


        }
        
    }


    private IEnumerator WalkStamDelay()
    {
        
        yield return new WaitForSeconds(1);
        //stam adjustments for walking 
       
    }
    //Calls the chop logic when right input is pressed and has enough stam 
    public void Chopping()
    {
        if (Input.GetMouseButton(0) && !isPressed && stats.StaminaCount > stats.AttackCost)
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
            if (Input.GetKey(KeyCode.F) && stats.CanBurnWood&&!isBuring&&stats.WoodCount != 0 )
            {
                
                isBuring = true;
                StartCoroutine(BurnWoodDelay());

            }
        }
       
        
    }


   public IEnumerator BurnWoodDelay()
    {
        textDisplay.text.SetActive(false);
        
        yield return new WaitForSeconds(2);
        textDisplay.text.SetActive(true);
        

        stats.WoodCount--;
        WoodText.text = "Wood: " + stats.WoodCount;
        isBuring = false;
       
        stats.StaminaCount = WoodBurnAmount + stats.StaminaCount;
        if (stats.StaminaCount > stats.MaxStamina) stats.StaminaCount = stats.MaxStamina;
        staminaBar.fillAmount = stats.StaminaCount / stats.MaxStamina;
        slider.value = staminaBar.fillAmount;
    }


    public void UseMouse()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
            
        }
    }
    public void Building()
    {
        if (stats != null)
        {
            if (Input.GetKeyUp(KeyCode.B) && stats.WoodCount > 4 && stats.StaminaCount > buildCost)
            {
                playerPos = transform.position;
                //playerRotation = transform.rotation;
                Vector3 buildPos = new Vector3(playerPos.x + 5, playerPos.y, playerPos.z);
                Debug.Log(buildPos);
                GameObject newCampfire = Instantiate(CampPreFab);
                newCampfire.transform.position = buildPos;

            }
        }
    }



}   












