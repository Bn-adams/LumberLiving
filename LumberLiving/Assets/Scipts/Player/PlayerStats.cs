using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float speed = 3f;

    private float jumpHeight = 2f;

    private int woodCount = 0;

   



    public float Speed { get => speed; set => speed = value; }
    public float JumpHeight { get => jumpHeight; set => jumpHeight = value; }
    private int WoodCount { get => woodCount; set => woodCount = value; }


}
