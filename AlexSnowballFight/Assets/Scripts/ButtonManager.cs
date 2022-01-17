using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayGame() // open our play scene
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ControlsScene() // open the controls scene
    {
        SceneManager.LoadScene("ControlsScene");
    }

    public void ExitGame() // quit game, only works when game is built
    {
        Application.Quit();
    }

    public void ReturnToMain() // opens main menu
    {
        SceneManager.LoadScene("MainMenu");
    }
}
