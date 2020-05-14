using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    private float spawnTime;
    [SerializeField]
    private GameObject coronaPrefab;
    [SerializeField]
    private float spawnDelay;
    public int enemyCounter;
    public int enemiesOnField;
    private int enemiesSpawnedThisRound = 0;

    private int newRoundTime = 10;
    private int newRoundDelay = 5;

    // Update is called once per frame
    void Update()
    {
        if(ShouldSpawn()){
            Spawn();
            enemiesSpawnedThisRound++;
        }
    }

    private void Spawn()
    {
        spawnTime = Time.time + spawnDelay;
        Instantiate(coronaPrefab, transform.position, transform.rotation, transform);
    }

    private bool ShouldSpawn()
    {
        return Time.time >= spawnTime && enemiesSpawnedThisRound < enemyCounter;
    }

    private void NewRound()
    {

    }

    private void ShouldNewRound()
    {
        return Time.time >= spawnTime && enemiesSpawnedThisRound < enemyCounter;
    }
}
