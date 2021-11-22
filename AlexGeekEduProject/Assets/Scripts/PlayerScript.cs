using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed; // our movement speed variable
    public Vector3 MoveDirection; // our direction for moving
    public Rigidbody Rigidbody;

    public float xRotation;
    public float yRotation;
    public float horizontalSpeed;
    public float verticalSpeed;
    public float JumpForce;

    public GameObject[] BlockToPlace; // the block we want to place
    public Transform PlacementPosition; // where we place the block

    public GameObject CurrentBlock;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // we're locking our mouse inside the game screen
        CurrentBlock = BlockToPlace[0]; // to make sure our current block is the normal block to start
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotatePlayer();
        PlaceBlock();
        SwitchBlock();
    }

    void PlaceBlock()
    {
        if (Input.GetMouseButtonDown(1)) // on right click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                PlacementPosition.position = hit.point + hit.normal * 0.5f;
                PlacementPosition.position = new Vector3(Mathf.Round(PlacementPosition.position.x), Mathf.Round(PlacementPosition.position.y), Mathf.Round(PlacementPosition.position.z));
                Instantiate(CurrentBlock, PlacementPosition.position, Quaternion.identity); // spawn the block on our placement position
            }
            
        }
    }

    void SwitchBlock()
    {
        if (Input.GetKeyDown("b")) // set our current block to the bouncy one
        {
            CurrentBlock = BlockToPlace[1];
        }
        if (Input.GetKeyDown("n")) // set our current block to the normal block
        {
            CurrentBlock = BlockToPlace[0];
        }
        if (Input.GetKeyDown("p"))
        {
            CurrentBlock = BlockToPlace[2];
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal"); // storing our horizontal movement
        float vertical = Input.GetAxis("Vertical"); // storing vertical movement
        MoveDirection = transform.forward * vertical + transform.right * horizontal; // storing which way we're facing
        Vector3 force = MoveDirection * (moveSpeed * Time.deltaTime); // applying the move speed to that direction
        transform.position += force; // the final step, moving our position

        if (Input.GetKeyDown("space"))
        {
            Rigidbody.AddForce(Vector3.up * JumpForce);
        }

        if (Input.GetKey(KeyCode.Z)) // resetting our rotation to 0,0,0
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    void RotatePlayer() // rotating the player
    {
        float mouseX = Input.GetAxis("Mouse X");
        yRotation = mouseX * horizontalSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y");
        xRotation = mouseY * verticalSpeed * Time.deltaTime;
        Vector3 PlayerRotation = transform.rotation.eulerAngles;
        PlayerRotation.x -= xRotation;
        PlayerRotation.y += yRotation;
        transform.rotation = Quaternion.Euler(PlayerRotation);
    }
}
