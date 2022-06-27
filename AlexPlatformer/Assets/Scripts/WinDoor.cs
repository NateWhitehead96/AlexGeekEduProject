using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinDoor : MonoBehaviour
{
    public bool inDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && inDoor == true)
        {
            if (GameManager.instance.LevelsBeaten < 10) // only when our levels beaten is less than "next level"
            {
                GameManager.instance.LevelsBeaten = 10; // the level we've beaten will be the current level
            }
            GameManager.instance.SaveGame(); // save our progress
            SceneManager.LoadScene("WinScreen"); // load the level by index
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // player touching door
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision) // player leaving door
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inDoor = false;
        }
    }
}
