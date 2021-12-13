using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaRising : MonoBehaviour
{

    public float moveSpeed;  // how fast the lava will rise

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime); // this will move the lava up
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("You got got by the lava");
            Cursor.lockState = CursorLockMode.None; // reverting the cursor back
            SceneManager.LoadScene(2); // load our game over scene
        }

        if (other.gameObject.CompareTag("Cube"))
        {
            Destroy(other.gameObject); // we delete the cubes getting swallowed by the lava
        }
    }
}
