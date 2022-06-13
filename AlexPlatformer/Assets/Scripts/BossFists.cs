using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossBrain
{
    Resetting, // resetting back to original position
    Tracking // tracking the player
}

public class BossFists : MonoBehaviour
{
    public Vector3 startPosition; // the position the fists start in
    public Transform player; // we can track the players position
    public BossBrain brain;

    public float timer; // when it hits the timer slam down
    public bool attacking; // to know if the fist is slamming or not
    public Rigidbody2D rb; // so it can use gravity to slam
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // set the starting position
    }

    // Update is called once per frame
    void Update()
    {
        if(brain == BossBrain.Resetting)
        {
            rb.velocity = Vector2.zero; // reset it's velocity
            transform.position = Vector3.MoveTowards(transform.position, startPosition, Time.deltaTime); // move the fist back to start position
            float distance = Vector3.Distance(transform.position, startPosition); // find distance between its current pos to the start pos
            if(distance <= 0.1f)
            {
                brain = BossBrain.Tracking; // set the hands to track player
            }
        }
        if(brain == BossBrain.Tracking)
        {
            if(attacking == false) // only move fists left and right if it hasnt dropped yet
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y), Time.deltaTime);
            if (timer >= 3)
            {
                attacking = true;
                rb.gravityScale = 5; // make the fist slam
            }
            timer += Time.deltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerScript>() && attacking == true)
        {
            collision.gameObject.GetComponent<PlayerScript>().PlayerHurt(); // deal damage to player when fist is slamming
            rb.gravityScale = 0; // resets gravity
            attacking = false;
            brain = BossBrain.Resetting;
            timer = 0;
        }
        if (collision.gameObject.CompareTag("Ground"))// it missed and hit the ground
        {
            rb.gravityScale = 0; // resets gravity
            attacking = false;
            brain = BossBrain.Resetting;
            timer = 0;
        }
    }
}
