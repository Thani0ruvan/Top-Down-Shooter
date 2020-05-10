using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] Transform[] EnemySpawnpoints;

    [SerializeField] int MinValue;
    [SerializeField] int MaxValue;

    [SerializeField]public float SpawnbetweenTime=10;
    float ResetTime;

    public List<Enemy> EnemyAliveList;

    public static SpawnEnemy _instance;

    public GameObject bloodEff;
    private void Awake()
    {

        _instance = this;
        ResetTime = SpawnbetweenTime;
        EnemyAliveList = new List<Enemy>();
    }
    private void Update()
    {
        if (!GamePlayManager.GetInstance().IsGameTimeFinished)
        {
            if (SpawnbetweenTime <= 0)
            {
                InstanEnemy();
                SpawnbetweenTime = ResetTime;
            }
            else
                SpawnbetweenTime -= Time.deltaTime;
        }
        else
        {
            if(EnemyAliveList.Count == 0)
            {
                GamePlayManager.GetInstance().IsEnemyKilled(true);
            }
        }
    }
    void InstanEnemy()
    {   int SpawnCount =Random.Range(MinValue, MaxValue+1);
        for (int i = 0; i < SpawnCount; i++) {
            Transform SpawnPoint = EnemySpawnpoints[Random.Range(0, EnemySpawnpoints.Length)];

            GameObject currentEnemy= Instantiate(EnemyPrefab, SpawnPoint.position, Quaternion.identity);

            EnemyAliveList.Add(currentEnemy.GetComponent<Enemy>());
        } 
    }

    public static SpawnEnemy GetInstance()
    {
        return _instance;
    }

}
