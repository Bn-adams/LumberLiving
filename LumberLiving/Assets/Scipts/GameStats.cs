using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    private float speed = 5f;

    private float jumpHeight = 2f;

    private int mapSize = 3;

 

    public float Speed { get => speed; set => speed = value; }
    public float JumpHeight { get => jumpHeight; set => jumpHeight = value; }
    public int MapSize { get => mapSize; set => mapSize = value; }


   

    

}
