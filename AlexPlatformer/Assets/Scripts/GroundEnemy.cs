using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public float moveSpeed; // how fast ground enemy moves
    public int direction;
    public float leftBounds; // how far to the left it can go
    public float rightBounds; // how far to the right it can go
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * direction * Time.deltaTime, transform.position.y); // move the enemy on the X axis

        if(transform.position.x < leftBounds)
        {
            direction = 1; // go to the right
        }
        if(transform.position.x > rightBounds)
        {
            direction = -1; // go to the left
        }
    }
}
