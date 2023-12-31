using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class TreeMining : MonoBehaviour
{
    public bool canBeHarvested;
    public bool isHarvested = false;
    
   
    
    [SerializeField]
    private GameObject Wood;
    private float waitTime = 0.7f;
    
    private PlayerController playerController;
    private PlayerStats stats;
    

    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    //used to delay the logic of the on destroy logic till after the animation and spawns then wood then aswell 
    public IEnumerator TreeDestroy()
    {
        isHarvested = true;
        canBeHarvested = false;
        yield return new WaitForSeconds(waitTime);
        GameObject.Destroy(gameObject);
        if (isHarvested)
        {
            Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-1, 1) , 0.2f, UnityEngine.Random.Range(-1, 1)) ;
            Vector3 spawnPosition = randomPosition;
            GameObject newWood = Instantiate(Wood, transform.parent.position + spawnPosition, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        ChopCheck();
    }
    //checks the player is close enough 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TreeZone"))
        {
            Debug.Log("InZone");
            canBeHarvested = true;
        }
    }
   //runs the destroy logic when the player is near and attacking
    public void ChopCheck()
    {
        if (canBeHarvested && playerController.isAttacking)
        {
            Debug.Log("CheckComplete");
            StartCoroutine(TreeDestroy());
        }
    }
}
