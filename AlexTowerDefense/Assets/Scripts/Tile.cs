using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isOccupied; // to know if a tower is on this tile or not
    public Color unoccupiedColor; // the color itll be by default
    public Color occupiedColor; // the color it will become when a tower is place
    public SpriteRenderer sprite; // help us change the color of the tile

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // auto assign sprite renderer
    }

    private void Update()
    {
        if(isOccupied == true)
        {
            sprite.color = occupiedColor;
        }
        if(isOccupied == false)
        {
            sprite.color = unoccupiedColor;
        }
    }
}
