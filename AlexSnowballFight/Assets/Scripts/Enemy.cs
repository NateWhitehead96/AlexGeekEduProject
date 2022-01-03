using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int moveSpeed;
    public GameObject HitEffect; // a gameobject reference to our particle system
    public GameObject effect;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y); // this will move it to the left

        if(transform.position.x < -10)
        {
            // we lose health or lives
            ScoringSystem.Lives--; // when the enemy gets past our player we lose a life
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snowball"))
        {
            Destroy(collision.gameObject); // destroy snowball
            // gain score/points
            ScoringSystem.Score += 5; // gaining score
            
            StartCoroutine(Dying());
        }
    }

    IEnumerator Dying()
    {
        // disable animation and colliders
        animator.SetBool("isDying", true);
        gameObject.GetComponent<BoxCollider2D>().enabled = false; // disable the collider to allow other enemies to pass
        moveSpeed = 0;
        // play the effect
        effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);
        // destroy this gameobject
        Destroy(effect); // destroy the particle effect
        Destroy(gameObject); // destroy enemy
    }
}
