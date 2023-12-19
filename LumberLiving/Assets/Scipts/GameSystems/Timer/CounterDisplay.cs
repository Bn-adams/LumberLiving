using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimerText;

    GameStats stats;
    
    
    // Start is called before the first frame update
    void Start()
    {
        stats = GameObject.Find("GameSystems").GetComponent<GameStats>();
        stats.GameClockMax = 60;
        stats.GameClockCurrent = 60;

    }

    // Update is called once per frame
    void Update()
    {
        TimerCount();
    }
    public void TimerCount()
    {
        stats.GameClockCurrent -= Time.deltaTime;
        TimerText.text = ((int)stats.GameClockCurrent).ToString();

        
    }
  
}
