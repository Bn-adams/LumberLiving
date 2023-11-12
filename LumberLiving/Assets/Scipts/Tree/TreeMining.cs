using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeMining : MonoBehaviour
{
    public bool canBeHarvested;
    public bool isHarvested = false;
    [SerializeField]
    private GameObject Wood;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canBeHarvested && Input.GetKey(KeyCode.Space))
        {
            GameObject.Destroy(gameObject);
            isHarvested = true;
        }

        if (isHarvested)
        {
            Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(-2, 2), 0, UnityEngine.Random.Range(-2,2));
            Vector3 spawnPosition = randomPosition;
            GameObject newWood = Instantiate(Wood, transform.parent.position + spawnPosition, Quaternion.identity);
            
        }
    
    }
    

}
