using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    public void ResumeGame()
    {
        Time.timeScale = 1;
        FindObjectOfType<ShootSnowball>().Paused = false;
        gameObject.SetActive(false);
    }
}
