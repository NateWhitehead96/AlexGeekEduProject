using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    // references to our text objects
    public Text LivesText;
    public Text ScoreText;
    public Text WavesText;

    // static key word allows us to get these variables in other classes without a reference
    // our game's main variables
    public static int Lives;
    public static int Score;
    public static int Wave; // the current wave we're on
    // Start is called before the first frame update
    void Start()
    {
        Lives = 3; // our statring amount of lives
    }

    // Update is called once per frame
    void Update()
    {
        LivesText.text = "Lives: " + Lives;
        ScoreText.text = "Score: " + Score;
        WavesText.text = "Wave: " + Wave;

        if(Lives <= 0) // when we hit 0 lives go to game over scene
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
