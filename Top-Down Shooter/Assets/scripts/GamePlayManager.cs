using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{   //In Minites
    float GameTime = 0.5f;

    float GameTimeSeconds;

    bool StartClockTime;

    bool IsFinished=false;
    private void Awake()
    {
        GameTimeSeconds = GameTime * 60f;
    }
    private void Start()
    {
        StartClock();
    }

    void StartClock()
    {
        StartClockTime = true;
    }
    private void Update()
    {
        if (StartClockTime)
        {
            RunClock();
        }
    }
    void RunClock()
    {
        if (GameTimeSeconds<=0)
        {
            Debug.Log("GameFinished");
        }
        else
        {
            GameTimeSeconds -= Time.deltaTime;
        } 
    }
}
