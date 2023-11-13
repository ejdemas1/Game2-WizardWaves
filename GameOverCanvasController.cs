using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverCanvasController : MonoBehaviour
{
    public TextMeshProUGUI totalEnemies;
    public TextMeshProUGUI totalWaves;
    void Update()
    {
        int totalEnemiesDefeated = PlayerPrefs.GetInt("TotalEnemies" ,0);
        totalEnemies.text = "Total Enemies Defeated: " + totalEnemiesDefeated;

        int totalWavesCompleted = PlayerPrefs.GetInt("WavesCompleted" ,0);
        totalWaves.text = "Total Waves Completed: " + totalWavesCompleted;
    }
}
