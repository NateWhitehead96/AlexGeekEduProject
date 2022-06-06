using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// this script will just have button on click functions
public class ButtonManager : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1; // resume time
        gameObject.SetActive(false); // hide the canvas holding this script
    }

    public void ReturntoHub()
    {
        SceneManager.LoadScene(1); // load hubworld
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Revive()
    {
        GameManager.instance.Lives = 3;
        SceneManager.LoadScene(0);
    }

    // Main menu buttons
    public void PlayGame()
    {
        SceneManager.LoadScene("HubWorld"); // load hub world
    }
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings"); // load our settings menu
    }
    public void ExitGame()
    {
        Application.Quit(); // close the game, only works in built version
    }
}
