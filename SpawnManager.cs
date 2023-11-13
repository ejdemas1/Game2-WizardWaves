using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public WaveManager waveManager;
    public GameObject[] enemies;
    public GameObject[] spawnPoints;
    public void StartSpawns()
    {
        StartCoroutine(StartSpawnLogic());
    }

    public IEnumerator StartSpawnLogic()
    {   
        for (int i = 0; i < waveManager.enemiesToSpawn; i++) {
            int enemyIndex = Random.Range(0, 4);
            int spawnIndex = Random.Range(0, 3);
            Instantiate(enemies[enemyIndex], spawnPoints[spawnIndex].transform.position, Quaternion.identity);
            waveManager.enemiesLeft++;
             yield return new WaitForSeconds(1f);
        }

        waveManager.startOfWave = false;

    }
}
