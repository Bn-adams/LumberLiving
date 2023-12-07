using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndConditionCheck : MonoBehaviour
{
    PlayerStats playerStats;
    GameStats gameStats;
    private bool EndGameConditionMet = false;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        gameStats = GameObject.Find("GameSystems").GetComponent<GameStats>();
    }

    // Update is called once per frame
    void Update()
    {
        staminaCheck();
        TimerCheck();
    }
    void staminaCheck()
    {
        if (playerStats != null)
        {
            if(playerStats.StaminaCount < 0.05f)
            {
                Debug.Log("EndGame");
                EndGameConditionMet = (true);
            }
        }
    }
    void TimerCheck()
    {
        if (gameStats != null)
        {
            if(gameStats.GameClockCurrent < 0)
            {
                EndGameConditionMet = (true);
                Debug.Log("EndGame");
            }
        }
    }
}
