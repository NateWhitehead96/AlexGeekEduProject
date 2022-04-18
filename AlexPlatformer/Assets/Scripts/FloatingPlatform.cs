using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    public float moveSpeed;
    public float leftBounds;
    public float rightBounds;
    public int direction;
    public float stopTimer;
    public bool droppingOff; // help with stopping the platform to drop player off
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(droppingOff == false) // moving the platform
        {
            transform.position = new Vector3(transform.position.x + direction * moveSpeed * Time.deltaTime, transform.position.y);
        }
        if(transform.position.x >= rightBounds)
        {
            direction = -1;
            droppingOff = true;
        }
        if(transform.position.x <= leftBounds)
        {
            direction = 1;
            droppingOff = true;
        }
        if(droppingOff == true)
        {
            stopTimer += Time.deltaTime;
            if(stopTimer >= 2)// wait for 2 seconds
            {
                droppingOff = false;
                stopTimer = 0;
            }
        }
    }
}
