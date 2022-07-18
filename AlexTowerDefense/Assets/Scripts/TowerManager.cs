using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public int gold; // games currancy for buying towers
    public Tower towerToPlace; // to know which tower we are placing
    public CustomCursor customCursor; // access to the cursor
    public Tile[] tiles; // to know about all of our tiles in the game
    // Start is called before the first frame update
    void Start()
    {
        customCursor.gameObject.SetActive(false); // hide the cursor on start
    }

    // Update is called once per frame
    void Update()
    {
        
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
