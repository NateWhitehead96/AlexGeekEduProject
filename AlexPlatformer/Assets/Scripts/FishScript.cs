using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public bool upDown; // this bool is to know if the fish is going up and down, or left and right

    public float leftBounds;
    public float rightBounds;

    public float upBounds;
    public float downBounds;

    public int direction;
    public int moveSpeed;

    private SpriteRenderer sprite; // to help flip the sprite
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if(direction > 0)
        {
            sprite.flipX = true; // so the fish faces right on start if going in the right direction
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(upDown == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * direction * Time.deltaTime); // move
            if(transform.position.y > upBounds)
            {
                direction = -1;
            }
            if(transform.position.y < downBounds)
            {
                direction = 1;
            }
        }
        if(upDown == false)
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * direction * Time.deltaTime, transform.position.y);
            if(transform.position.x > rightBounds)
            {
                direction = -1;
                sprite.flipX = false; // facing left
            }
            if(transform.position.x < leftBounds)
            {
                direction = 1;
                sprite.flipX = true; // facing right
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().PlayerHurt(); // this will hurt the player and play the animation
        }
    }
}
