using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text gameOverText;
    public EnemySpawner enemySpawner; // access to this for it's wave #
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameOverText.text = "You lost on wave " + enemySpawner.wave + " , better luck next time lol.";
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0); // this might change, but reopens our play scene for now
    }
}
