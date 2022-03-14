using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thwamp : MonoBehaviour
{
    public float movespeed; // how fast to floats back up
    private Rigidbody2D rb;
    public float RestingYPosition; // it's top Y position
    public bool fellDown; // to know if the thing fell down
    public Transform RaycastPosition; // the raycast start position
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(RaycastPosition.position, Vector2.down, Mathf.Infinity);
        if(hit.collider.gameObject.CompareTag("Player") && fellDown == false) // player passes under
        {
            rb.gravityScale = 10;
            fellDown = true;
        }
        if(transform.position.y < RestingYPosition && fellDown == true) // once it falls make sure it floats back up
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + movespeed * Time.deltaTime);
        }
        if(transform.position.y >= RestingYPosition) // once its reached the top flip bool
        {
            fellDown = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.gravityScale = 0; // once it slams down, make gravity 0 so it can float up
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().PlayerHurt(); // hurt the player
        }
    }
}
