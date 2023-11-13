using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
   private int currentWave = 1;

   private int enemiesLeft;
   public TextMeshProUGUI current_wave_text;

   public TextMeshProUGUI enemy_counter_text;
   public WaveManager waveManager;
    void Update()
    {
        if (waveManager.start_game) {
            currentWave = waveManager.currentWave;
            current_wave_text.text = "Current Wave: " + currentWave;

            enemiesLeft = waveManager.enemiesLeft;
            enemy_counter_text.text = "Enemies Left: " + enemiesLeft;
        }

    }
}
