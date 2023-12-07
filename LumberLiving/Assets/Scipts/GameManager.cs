using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    private Spawner gSpawner;
    private GameStats stats;
    
    
    private void SpawnGround()
    {
        GameObject newGround = gSpawner.Spawn(gameObject);
        stats = GameObject.Find("Player").GetComponent<GameStats>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnGround();

        /*
        for (int i = 0; i < MapSize; i++)
        {

            Debug.Log("first for loop");
            for (int j = 0; j < MapSize; j++)
            {
                Debug.Log("Second for loop");

                SpawnGround();
            }
        }
        */
        
        
    }

    // Update is called once per frame
    void Update()
    {
        CounterCheck();
    }
    public void CounterCheck()
    {
        if(stats != null)
        {
            if(stats.GameClockCurrent == 0)
            {
                Debug.Log("Game end");
                GameEnd();
            }
        }
    }
    private void GameEnd()
    {
        
    }
}
