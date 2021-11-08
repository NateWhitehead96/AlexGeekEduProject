using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed; // our movement speed variable
    public Vector3 MoveDirection; // our direction for moving
    public Rigidbody Rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey("w")) // moving forward
        {
            transform.Translate(transform.forward * (moveSpeed * Time.deltaTime));
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveSpeed * Time.deltaTime);
            //Rigidbody.AddForce(Vector3.forward * moveSpeed);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(-transform.right * (moveSpeed * Time.deltaTime));
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(transform.right * (moveSpeed * Time.deltaTime));
        }
        //float horizontal = Input.GetAxis("Horizontal"); // storing our horizontal movement
        //float vertical = Input.GetAxis("Vertical"); // storing vertical movement
        //MoveDirection = transform.forward * vertical + transform.right * horizontal; // storing which way we're facing
        //Vector3 force = MoveDirection * (moveSpeed * Time.deltaTime); // applying the move speed to that direction
        //transform.position += force; // the final step, moving our position
    }
}
