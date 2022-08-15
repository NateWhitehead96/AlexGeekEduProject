using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float timer;
    public int wave = 1; // what wave we're on
    public int enemiesRemaining; // how many enemies to spawn/how many are remaining
    public int currentEnemy; // know what enemy to spawn
    public Text waveDisplay; // display our current wave
    // Start is called before the first frame update
    void Start()
    {
        waveDisplay.gameObject.SetActive(false); // hide wave display to start
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 1 && enemiesRemaining > 0) // the timer hits 1 and we still have enemies to spawn
        {
            Instantiate(enemy[currentEnemy], transform.position, transform.rotation); // spawning enemy
            timer = 0;
            enemiesRemaining--; // subtract from the total of enemies to spawn
            if(enemiesRemaining == 0)
            {
                StartCoroutine(StartNextWave());
            }
        }
        timer += Time.deltaTime;
    }

    IEnumerator StartNextWave()
    {
        yield return new WaitForSeconds(10);
        wave++; // increase wave number
        waveDisplay.gameObject.SetActive(true); // show the wave display
        waveDisplay.text = "Wave " + wave + " incoming!"; // display "Wave X incoming!"
        enemiesRemaining += wave * 2; // increase how many enemies come out
        if(wave >= 5)
        {
            currentEnemy = 1; // spawn skeletons
        }
        if (wave >= 10)
        {
            currentEnemy = 2; // spawn ghosts
        }
        if (wave >= 15)
        {
            currentEnemy = 3; // spawn bats
        }
        if (wave >= 20)
        {
            currentEnemy = 4; // spawn mummy
        }
        yield return new WaitForSeconds(2); // wait 2 seconds
        waveDisplay.gameObject.SetActive(false); // hide display
    }
}
