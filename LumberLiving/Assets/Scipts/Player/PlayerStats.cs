using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float speed = 4f;

    private float jumpHeight = 2f;

    private int woodCount = 0;

    private float maxStamina;

    private float minStamina;

    private float staminaCount;

    private float attackCost = 5;

    private float walkCost = 0.5f;

    private bool canBurnWood = false;


    

   



    public float Speed { get => speed; set => speed = value; }
    public float JumpHeight { get => jumpHeight; set => jumpHeight = value; }
    public int WoodCount { get => woodCount; set => woodCount = value; }
    public float MaxStamina { get => maxStamina; set => maxStamina = value; }
    public float MinStamina { get => minStamina; set =>minStamina = value; }
    public float StaminaCount { get => staminaCount; set => staminaCount = value; }
    public float AttackCost { get => attackCost; set => attackCost = value; }
    public float WalkCost { get => walkCost; set => walkCost = value; }
    public bool CanBurnWood { get => canBurnWood; set => canBurnWood = value; }
        
}
