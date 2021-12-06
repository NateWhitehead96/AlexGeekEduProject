using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void PlayButton() // the play button functionality
    {
        SceneManager.LoadScene(1); // loading our play scene
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
