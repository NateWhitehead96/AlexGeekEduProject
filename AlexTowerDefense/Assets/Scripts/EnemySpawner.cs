using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 2)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
