using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubble;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 3)
        {
            Instantiate(bubble, transform.position, transform.rotation);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
