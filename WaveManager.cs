using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    
    public int currentWave = 1;
    public int enemiesToSpawn = 4;
    public int enemiesLeft = 0;
    public bool startOfWave = true;

    public bool start_game = true;

    public int totalEnemiesDefeated = 0;
    private SpawnManager spawnManager;
    void Start()
    {
        
        if (start_game) {
            spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
            StarWaveLogic();
            PlayerPrefs.SetInt("TotalEnemies", totalEnemiesDefeated);
            PlayerPrefs.SetInt("WavesCompleted", currentWave - 1);
        }
    }

    void Update()
    {
        if (enemiesLeft <= 0 && !startOfWave){
            enemiesLeft = 0;
            currentWave++;
            PlayerPrefs.SetInt("WavesCompleted", currentWave - 1);
            enemiesToSpawn++;
            StarWaveLogic();
        }
    }

    public void StarWaveLogic() {
        if (enemiesLeft != enemiesToSpawn || currentWave == 1) {
            spawnManager.StartSpawns();
        }
    }

    
}
