using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{
    public int gold; // games currancy for buying towers
    public Tower towerToPlace; // to know which tower we are placing
    public CustomCursor customCursor; // access to the cursor
    public Tile[] tiles; // to know about all of our tiles in the game
    public Text goldDisplay; // updating how much gold the player has
    // Start is called before the first frame update
    void Start()
    {
        customCursor.gameObject.SetActive(false); // hide the cursor on start
    }

    // Update is called once per frame
    void Update()
    {
        PlaceTower();
        goldDisplay.text = "Gold: " + gold; // this will display our current gold
    }

    public void PlaceTower() // how we place towers
    {
        if(Input.GetMouseButtonDown(0) && towerToPlace != null) // left click and our tower is on our mouse
        {
            Tile nearestTile = null; // the closest tile
            float nearestDistance = float.MaxValue; // that tiles distance

            foreach(Tile tile in tiles)
            { // find distance from each tile to our mouse position
                float distance = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if(distance < nearestDistance) // if the distance is the lowest amount
                {
                    nearestDistance = distance; // that is the distance to the tile
                    nearestTile = tile; // make this our nearest tile
                }
            }
            if(nearestTile.isOccupied == false) // if that tile is not occupied
            {
                Tower newTower = Instantiate(towerToPlace, nearestTile.transform.position, transform.rotation); // spawn our tower at the tile
                newTower.tile = nearestTile; // set the tile
                nearestTile.isOccupied = true; // set to occupied
                towerToPlace = null; // clear our tower
                Cursor.visible = true; // show default cursor
                customCursor.gameObject.SetActive(false); // hide custom cursor
            }
        }
    }

    public void BuyTower(Tower tower)
    {
        if(gold >= tower.cost)
        {
            customCursor.gameObject.SetActive(true);
            customCursor.GetComponent<SpriteRenderer>().sprite = tower.GetComponent<SpriteRenderer>().sprite; // makes cursor same image as tower
            Cursor.visible = false; // optional but hides the default cursor
            gold -= tower.cost;
            towerToPlace = tower; // assign this tower we want to build to be the tower to place
        }
    }
}
