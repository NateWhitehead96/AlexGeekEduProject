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

    // Amount of blocks
    public int NumNormalBlocks;
    public int NumBouncyBlocks;
    public int NumPhysicsBlocks;

    public int BlockNum; // corresponds to block to place array

    public bool jumping; // this bool keeps track of our jumping

    // Showing current block
    public GameObject HeldBlock; // the block we're holding
    public Material[] BlockMaterials;
    public LayerMask GroundMask;

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
        GroundCheck();
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

                if (CurrentBlock == BlockToPlace[0] && NumNormalBlocks > 0) // we want to place a normal block
                {
                    NumNormalBlocks--;
                    Instantiate(CurrentBlock, PlacementPosition.position, Quaternion.identity); // spawn the block on our placement position
                }
                if (CurrentBlock == BlockToPlace[1] && NumBouncyBlocks > 0) // we want to place a bouncy block
                {
                    NumBouncyBlocks--;
                    Instantiate(CurrentBlock, PlacementPosition.position, Quaternion.identity); // spawn the block on our placement position
                }
                if (CurrentBlock == BlockToPlace[2] && NumPhysicsBlocks > 0) // we want to place a physics block
                {
                    NumPhysicsBlocks--;
                    Instantiate(CurrentBlock, PlacementPosition.position, Quaternion.identity); // spawn the block on our placement position
                }

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

        if (Input.GetKeyDown("e")) // going forward through our current blocks
        {
            BlockNum++;
            if(BlockNum >= BlockToPlace.Length) // if we've cycled past our alloted blocks reset to 0
            {
                BlockNum = 0;
                CurrentBlock = BlockToPlace[BlockNum];
            }
            CurrentBlock = BlockToPlace[BlockNum]; // make our current block the next block
        }

        HeldBlock.GetComponent<MeshRenderer>().material = BlockMaterials[BlockNum];

        
        //if (Input.GetKeyDown("q"))
        //{
        //    BlockNum--;
        //    if(BlockNum < 0) // going back through our current blocks
        //    {
        //        BlockNum = BlockToPlace.Length; // set it to the max number
        //        CurrentBlock = BlockToPlace[BlockNum];
        //    }
        //    CurrentBlock = BlockToPlace[BlockNum];
        //}

    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal"); // storing our horizontal movement
        float vertical = Input.GetAxis("Vertical"); // storing vertical movement
        MoveDirection = transform.forward * vertical + transform.right * horizontal; // storing which way we're facing
        Vector3 force = MoveDirection * (moveSpeed * Time.deltaTime); // applying the move speed to that direction
        transform.position += force; // the final step, moving our position

        if (Input.GetKeyDown("space") && jumping == false) // we're hitting space and not jumping, then jump
        {
            Rigidbody.AddForce(Vector3.up * JumpForce);
            jumping = true; // set our player to jumping
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

    void GroundCheck()
    {
        //Ray ray;
        //RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, 1f, GroundMask))
        {
            jumping = false;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Cube")) // when we land or collide with a cube, set jumping to false
    //    {
    //        jumping = false;
    //    }
    //}

}
