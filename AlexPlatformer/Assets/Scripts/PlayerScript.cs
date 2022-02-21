using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed; // how fast the player can move
    public float jumpForce; // how high we can jump
    public Rigidbody2D rb; // rigidbody

    public Animator animator; // our animation controller

    private SpriteRenderer sprite; // our player's sprite

    // animator helpers
    public bool walking;
    public bool jumping;
    public bool climbing;

    public static int Score; // the player's score
    public static int Health; // the player's health

    public bool hasKey; // this will tell if the player has the key for the level or not

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // makes sure our sprite is the sprite the script is attached to
        Health = 3; // assign health
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) // moving right
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            walking = true;
            sprite.flipX = false; // flipping direction sprite is facing
        }
        else if (Input.GetKeyUp(KeyCode.D)) // stop walking when we lift off of the d key
        {
            walking = false;
        }
        if (Input.GetKey(KeyCode.A)) // move left
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            walking = true;
            sprite.flipX = true; // flipping direction sprite is facing
        }
        else if (Input.GetKeyUp(KeyCode.A)) // stop walking when we lift off of the a key
        {
            walking = false;
        }

        animator.SetBool("isWalking", walking); // this will take care of switching to the walking animation
        animator.SetBool("isJumping", jumping); // this will take care of switching to the jump animation

        if (Input.GetKeyDown(KeyCode.Space) && jumping == false) // jump
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            jumping = true;
        }
        if (Input.GetKey(KeyCode.W) && climbing == true) // when we press W, we move up
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && climbing == true) // when we press S, we move down
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false; // land on anything we stop jumping
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Head"))
        {
            Destroy(collision.transform.parent.gameObject); // destroy the whole spider or ground enemy
        }
        if (collision.gameObject.CompareTag("Ladder")) // if that object is a ladder
        {
            climbing = true;
            rb.gravityScale = 0;
        }
        if(collision.gameObject.name == "Key") // we touch the key of the level this time by checking the name of the object
        {
            hasKey = true; // set collecting key to true
            Destroy(collision.gameObject); // destroy the key
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder")) // if that object is a ladder
        {
            climbing = false;
            rb.gravityScale = 1;
        }
    }

}
