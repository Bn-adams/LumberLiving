using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    private ISpawner gSpawner;
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

       

    }
}
    