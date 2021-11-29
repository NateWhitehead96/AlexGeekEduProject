using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    public Text ScoreText;
    public float Score;

    public PlayerScript player;

    public Text NumNormal;
    public Text NumBouncy;
    public Text NumPhysics;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score += Time.deltaTime; // increase our score
        ScoreText.text = "Score: " + Score.ToString("n2");

        // to display the number of blocks we have on our text objects
        NumNormal.text = "Normal Left: " + player.NumNormalBlocks.ToString();
        NumBouncy.text = "Bouncy Left: " + player.NumBouncyBlocks.ToString();
        NumPhysics.text = "Physics Left: " + player.NumPhysicsBlocks.ToString();
    }

    public void ChangeBlockToDefault() // button click to change the current block to the defualt one
    {
        player.CurrentBlock = player.BlockToPlace[0];
    }

    public void ChangeBlockToBouncy() // button click to change the current block to the bouncy one
    {
        player.CurrentBlock = player.BlockToPlace[1];
    }

    public void ChangeBlockToPhysics()
    {
        player.CurrentBlock = player.BlockToPlace[2];
    }
}
