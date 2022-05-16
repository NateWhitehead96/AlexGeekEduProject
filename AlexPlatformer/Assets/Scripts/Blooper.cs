using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlooperBehaviour
{
    wander,
    chase
}

public class Blooper : MonoBehaviour
{
    public Transform player; // so the blooper knows about the players location
    public Rigidbody2D rb; // to help move the bloopa around
    public float upForce; // help move it upwards
    public float horizontalForce; // help move it left and right
    public BlooperBehaviour behaviour; // to help know if it's wandering or if its chasing the player
    public float timer;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>().transform; // this links player to our player in game
        rb = GetComponent<Rigidbody2D>(); // link rb to this gameobjects rigidbody
        sprite = GetComponent<SpriteRenderer>(); // link to spriterenderer to flip the sprite
    }

    // Update is called once per frame
    void Update()
    {
        if(behaviour == BlooperBehaviour.wander) // the bloopa is wandering around
        {
            if(timer >= 1.5f) // time to move it
            {
                rb.AddForce(Vector2.up * upForce, ForceMode2D.Impulse);
                int randomDirection = Random.Range(0, 2); // be a 50% chance of being 0 or 1
                if(randomDirection == 0)
                {
                    rb.AddForce(Vector2.left * horizontalForce, ForceMode2D.Impulse);
                    sprite.flipX = false; // face left
                }
                if(randomDirection == 1)
                {
                    rb.AddForce(Vector2.right * horizontalForce, ForceMode2D.Impulse);
                    sprite.flipX = true; // face right
                }
                timer = 0;
            }
            timer += Time.deltaTime;
            float distanceToPlayer = Vector3.Distance(transform.position, player.position); // tell us how far player is from blooper
            if(distanceToPlayer <= 12) // player is within a screen distance from the blooper
            {
                behaviour = BlooperBehaviour.chase;
                rb.gravityScale = 0; // to help with chasing the player
            }
        }
        if(behaviour == BlooperBehaviour.chase)
        {
            rb.velocity = Vector2.zero; // to fix
            transform.position = Vector3.MoveTowards(transform.position, player.position, horizontalForce * Time.deltaTime); // chase the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position); // tell us how far player is from blooper
            if (transform.position.x > player.position.x) // player is to the left of blooper
                sprite.flipX = false; // face left
            if (transform.position.x < player.position.x) // player is to the right of blooper
                sprite.flipX = true; // face right
            if (distanceToPlayer >= 12) // player is outside a screen distance from the blooper
            {
                behaviour = BlooperBehaviour.wander;
                rb.gravityScale = 0.2f; // so it has gravity to keep it in the water
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerScript>())
        {
            collision.gameObject.GetComponent<PlayerScript>().PlayerHurt();
        }
    }
}
