using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text ScoreText; // the score text
    // access to the players hearts
    public Image HeartOne;
    public Image HeartTwo;
    public Image HeartThree;

    public Sprite EmptyHeart; // the image of an empty heart
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = PlayerScript.Score.ToString(); // update the text with our score

        if(PlayerScript.Health == 2) // we lost 1 health
        {
            HeartOne.sprite = EmptyHeart; // assign the empty hear to the first heart
        }
        if(PlayerScript.Health == 1) // we lost 2 health
        {
            HeartTwo.sprite = EmptyHeart;
        }
        // if health = 0 then we'd just die and show a new screen
    }
}
