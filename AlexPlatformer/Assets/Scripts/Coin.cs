using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float moveSpeed; // how fast it moves
    public int direction; // is either 1 or -1 for up and down respectively
    public float topBounds; // how high it can go
    public float botBounds; // how low it can go

    // Start is called before the first frame update
    void Start()
    {
        topBounds = transform.position.y + 0.2f; // small hieght from the original spot
        botBounds = transform.position.y - 0.2f; // small bottom bound from original spot
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * direction * Time.deltaTime); // moving the coin in a direction
        if(transform.position.y > topBounds)
        {
            direction = -1; // make the coin go down
        }
        if(transform.position.y < botBounds)
        {
            direction = 1; // make the coin go up
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // get score, add coin to whatever play sound effect if we want
            PlayerScript.Score++; // add to our score
            SoundManager.instance.pickup.Play(); // plays the pickup sound
            Destroy(gameObject); // destroy the coin
        }
    }
}
