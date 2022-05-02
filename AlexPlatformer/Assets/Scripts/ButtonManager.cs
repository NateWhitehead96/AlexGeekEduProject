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
        SceneManager.LoadScene(0); // load hubworld
    }

    public void Revive()
    {
        GameManager.instance.Lives = 3;
        SceneManager.LoadScene(0);
    }
}
