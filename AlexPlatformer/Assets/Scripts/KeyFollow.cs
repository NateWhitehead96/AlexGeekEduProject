using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offSet; // an addition to the player position to make sure the key is not inside the player
    public bool collected;
    public DoorScript exitDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(collected == true)
        {
            Vector3 followPosition = player.position + offSet; // new position the key will always move toward
            transform.position = Vector3.Lerp(transform.position, followPosition, Time.deltaTime); // move key from its position to the follow position
            if (exitDoor.playerInDoor)
            {
                Destroy(gameObject); // when the player is inside the door "unlock the door"
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.transform; // make sure the player is the player transform
            collected = true;
        }
    }
}
