using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // help us move between scenes

public class DoorScript : MonoBehaviour
{
    public int LevelToLoad; // level we want to load
    public bool playerInDoor; // helps us know if player is touching door

    public bool needsKey; // depending on if the door is a level exit or a level start it might need a key
    public int CurrentLevel; // on the exit level doors to help assign what level we just beat
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (needsKey == true) // if we reach an exit level door
        {
            if (FindObjectOfType<PlayerScript>().hasKey && Input.GetKeyDown(KeyCode.W) && playerInDoor == true) // we have the key
            {
                GameManager.instance.LevelsBeaten = CurrentLevel; // the level we've beaten will be the current level
                SceneManager.LoadScene(LevelToLoad); // load the level by index
            }
        }
        else // the door doesnt need a key
        {        // pressing W                      we're in the door          we've beaten enough levels to enter
            if (Input.GetKeyDown(KeyCode.W) && playerInDoor == true && GameManager.instance.LevelsBeaten >= LevelToLoad) // we're hitting a key and we're inside the door
            {
                SceneManager.LoadScene(LevelToLoad); // load the level by index
            }
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
