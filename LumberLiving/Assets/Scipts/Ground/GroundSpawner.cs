using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour, Spawner
{
    [SerializeField] private GameObject GroundPreFab;
    private GameStats gameStats;
    
  
    private int MapSize = 25;
    private float spacing = 10f;

    void Start()
    {
        
    }
    public GameObject Spawn(GameObject caller)
    {
        for (int x = 0; x < MapSize; x++)
        {
            for (int y = 0; y < MapSize; y++)
            {
                Vector3 spawnPosition = new Vector3(x * spacing, 0, y * spacing); // Calculate the position based on grid and spacing.
                GameObject newGround = Instantiate(GroundPreFab, spawnPosition, Quaternion.identity);
                newGround.transform.parent = transform;

                //gets random number depending on number rotates the prefab one of 4 ways
                int rand = UnityEngine.Random.Range(1, 5);
                switch (rand)
                {
                    case 1:

                        newGround.transform.Rotate(0, 90f, 0);
                        break;
                    case 2:
                        newGround.transform.Rotate(0, 180f, 0);
                        break;
                    case 3:
                        newGround.transform.Rotate(0, 270f, 0);
                        break;
                    case 4:
                        break;
                }
            }
        }
        
       
        return null;


        /*
        GameObject newGround = Instantiate(GroundPreFab);
        newGround.transform.parent = transform;
        newGround.transform.position += new Vector3(0, 0, numSpawns * newGround.transform.localScale.z * newGround.transform.localScale.x);
        
        return newGround;
        */

    }

    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
