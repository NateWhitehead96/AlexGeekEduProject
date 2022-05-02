using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public Text ScoreText; // the score text
    // access to the players hearts
    public Image HeartOne;
    public Image HeartTwo;
    public Image HeartThree;

    public Sprite EmptyHeart; // the image of an empty heart
    public Sprite FullHeart; // the imgae of a full heart

    public Text LivesText; // how many lives we got
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = PlayerScript.Score.ToString(); // update the text with our score
        LivesText.text = GameManager.instance.Lives.ToString(); // update how many lives we have

        if(PlayerScript.Health == 3)
        {
            HeartOne.sprite = FullHeart;
            HeartTwo.sprite = FullHeart;
            HeartThree.sprite = FullHeart;
        }
        if(PlayerScript.Health == 2) // we lost 1 health
        {
            HeartOne.sprite = EmptyHeart; // assign the empty hear to the first heart
            HeartTwo.sprite = FullHeart;
            HeartThree.sprite = FullHeart;
        }
        if(PlayerScript.Health == 1) // we lost 2 health
        {
            HeartOne.sprite = EmptyHeart;
            HeartTwo.sprite = EmptyHeart;
            HeartThree.sprite = FullHeart;
        }
        if(PlayerScript.Health == 0)
        {
            GameManager.instance.Lives--; // subtract 1 life
            if(GameManager.instance.Lives <= 0)
            {
                SceneManager.LoadScene("GameOver"); // load the game over scene at 0 lives
            }
            PlayerScript.Health = 3; // reset health
            HeartOne.sprite = FullHeart; // update heart to be full heart
            HeartTwo.sprite = FullHeart; // update heart to be full heart
            FindObjectOfType<PlayerScript>().transform.position = FindObjectOfType<PlayerScript>().Checkpoint.position; // reset the position of the player
        }
        // if health = 0 then we'd just die and show a new screen
    }
}
