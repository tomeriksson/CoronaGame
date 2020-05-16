
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawning : MonoBehaviour
{

    private float spawnTime;
    [SerializeField]
    public GameObject coronaPrefab;
    [SerializeField]
    public float spawnDelay;
    public int enemyCounter;
    private int enemiesSpawnedThisRound = 0;

    private float newRoundTime;
    private float newRoundDelay = 10;
    private bool invokable = true;

    public Transform spawnNE;
    public Transform spawnNW;
    public Transform spawnSE;
    public Transform spawnSW;
    private System.Random rand = new System.Random();
    private Transform enemiesList;
    public Text score;
    private ScoreCounting counter;

    private void Start()
    {
        enemiesList = transform.GetChild(4);
        counter = score.GetComponent<ScoreCounting>();
    }
    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }

        NewRound();
    }

    private void Spawn()
    {
        spawnTime = Time.time + spawnDelay;
        switch (rand.Next(4))
        {
            case 0:
                Instantiate(coronaPrefab, spawnNE.position, spawnNE.rotation, enemiesList);
                break;
            case 1:
                Instantiate(coronaPrefab, spawnNW.position, spawnNW.rotation, enemiesList);
                break;
            case 2:
                Instantiate(coronaPrefab, spawnSE.position, spawnSE.rotation, enemiesList);
                break;
            case 3:
                Instantiate(coronaPrefab, spawnSW.position, spawnSW.rotation, enemiesList);
                break;
        }
        enemiesSpawnedThisRound++;
    }

    private bool ShouldSpawn()
    {
        return Time.time >= spawnTime && enemiesSpawnedThisRound < enemyCounter;
    }

    private void NewRound()
    {
        if (enemiesList.childCount == 0 && invokable)
        {
            Invoke("StartNewRound", newRoundDelay);
            counter.AddToScore();
            invokable = false;
        }
    }
    private void StartNewRound()
    {
        enemiesSpawnedThisRound = 0;
        enemyCounter = (int)Math.Round(enemyCounter * 1.25, 0) +1;
        invokable = true;
    }

}