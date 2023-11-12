using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeMiningCollision : MonoBehaviour
{
    private TreeMining treeMining;
    // Start is called before the first frame update
    void Start()
    {
        treeMining = GetComponent<TreeMining>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (treeMining != null)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                treeMining.canBeHarvested = true;
            }
        }
        
    }

}
