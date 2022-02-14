using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // help us move between scenes

public class DoorScript : MonoBehaviour
{
    public int LevelToLoad; // level we want to load
    public bool playerInDoor; // helps us know if player is touching door
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && playerInDoor == true) // we're hitting a key and we're inside the door
        {
            SceneManager.LoadScene(LevelToLoad); // load the level by index
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) // player touching door
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) // player leaving door
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInDoor = false;
        }
    }
}
