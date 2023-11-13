using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{

    private Rigidbody2D rb;
    public Sprite[] animations;
    public GameObject wizard;
    private float moveSpeed = 2f;
    private WaveManager waveManager;
    public AudioSource death;
    

    void Start()
    {
        waveManager = GameObject.Find("GameManager").GetComponent<WaveManager>();
    }

    void Update()
    {
        wizard = GameObject.FindGameObjectWithTag("Player");
        transform.position = Vector3.MoveTowards(transform.position, wizard.transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Fireball")
        {
            if (gameObject != null) {
                death.Play();
            }
            waveManager.enemiesLeft--;
            waveManager.totalEnemiesDefeated++;
            PlayerPrefs.SetInt("TotalEnemies", waveManager.totalEnemiesDefeated);
            Destroy(gameObject);
        }
    }
}
