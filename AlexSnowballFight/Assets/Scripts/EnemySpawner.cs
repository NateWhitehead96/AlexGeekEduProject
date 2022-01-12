using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float Bounds;
    public GameObject[] SpawnObjects;

    public float timer;
    public float SpawnTime = 2;

    public int NumberOfEnemies; // how many enemies to spawn for this wave

    // Start is called before the first frame update
    void Start()
    {
        ScoringSystem.Wave = 1;
        NumberOfEnemies = 3; // every wave increase enemy# by 3
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= SpawnTime && NumberOfEnemies > 0) 
        {
            SpawnNextThing();
        }
        timer += Time.deltaTime; // add to our timer

    }

    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(5); // wait 5 seconds then release the next wave
        ScoringSystem.Wave++;
        NumberOfEnemies += ScoringSystem.Wave * 3; // increase our enemies back to wave level times 3
    }

    public void SpawnNextThing() // this function will help us spawn either powerup or enemy
    {
        int x = Random.Range(0, 10);
        float randomY = Random.Range(-Bounds, Bounds); // find a random value between our bounds
        if (x == 0)
        {
            Instantiate(SpawnObjects[1], new Vector3(transform.position.x, randomY), Quaternion.identity); // spawn the powerup
        }
        else
        {
            GameObject newEnemy = Instantiate(SpawnObjects[0], new Vector3(transform.position.x, randomY), Quaternion.identity); // spawning the new enemy
            newEnemy.GetComponent<Enemy>().moveSpeed = Random.Range(1, ScoringSystem.Wave + 1); // the enemy move speed is a random number from 1 to the wave number
            timer = 0; // reset our timer
            NumberOfEnemies--;
            timer = 0;
            if (NumberOfEnemies <= 0)
            {
                // set us onto the next wave
                StartCoroutine(NextWave());
            }
        }
        
    }
}
