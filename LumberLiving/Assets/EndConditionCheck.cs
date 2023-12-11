using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (playerStats.StaminaCount < playerStats.MinStamina)
        {
            EndGameConditionMet = (true);
            Debug.Log("EndGame");
            SceneManager.LoadScene(2);
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
                SceneManager.LoadScene(2);
            }
        }
    }
}
