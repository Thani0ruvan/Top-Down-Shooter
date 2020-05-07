using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    static GamePlayManager _instance;
    
    //In Minites
    [SerializeField]float GameTime = 0.5f;

    float GameTimeSeconds;

    bool StartClockTime;

    bool IsFinished=false;

    [HideInInspector] public bool IsGameTimeFinished = false;
    bool IsAllEnemyWasKilled = false;
    private void Awake()
    {
        _instance = this;

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
        CheckForCheckPoint();
    }
    void RunClock()
    {
        if (GameTimeSeconds<=0)
        {
            IsGameTimeFinished = true;
        }
        else
        {
            GameTimeSeconds -= Time.deltaTime;
        } 
    }
    void CheckForCheckPoint()
    {
        if (IsGameTimeFinished && IsAllEnemyWasKilled)
        {
            Debug.Log("Checkpoint Reached");
        }
    }

  

    public static GamePlayManager GetInstance()
    {
        return _instance;
    }
    public void IsEnemyKilled(bool BOOL)
    {
        IsAllEnemyWasKilled = BOOL;
    }
}
