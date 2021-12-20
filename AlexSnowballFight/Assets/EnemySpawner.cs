using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float Bounds;
    public GameObject Enemy;

    public float timer;
    public float SpawnTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= SpawnTime)
        {
            float randomY = Random.Range(-Bounds, Bounds); // find a random value between our bounds
            Instantiate(Enemy, new Vector3(transform.position.x, randomY), Quaternion.identity); // spawning the new enemy
            timer = 0; // reset our timer
        }
        timer += Time.deltaTime; // add to our timer
    }
}
