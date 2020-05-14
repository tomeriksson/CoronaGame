
using System;
using System.Collections;
using UnityEngine;

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
        Instantiate(coronaPrefab, transform.position, transform.rotation, transform);
        enemiesSpawnedThisRound++;
    }

    private bool ShouldSpawn()
    {
        return Time.time >= spawnTime && enemiesSpawnedThisRound < enemyCounter;
    }

   private void NewRound() {
        if (transform.childCount == 0 && invokable) {
            Invoke("StartNewRound", newRoundDelay);
            invokable = false;
        }
    }
    private void StartNewRound() {
        enemiesSpawnedThisRound = 0;
        enemyCounter = (int)Math.Round(enemyCounter * 1.25, 0);
        invokable = true;
    }

}
