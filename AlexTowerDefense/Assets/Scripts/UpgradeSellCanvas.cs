using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSellCanvas : MonoBehaviour
{
    public Tower selectedTower; // help us know what tower this upgrade/sell thing should be on
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade()
    {
        if(FindObjectOfType<TowerManager>().gold >= 50)
        {
            // we want to increase damage to our tower
        }
        transform.position = new Vector3(100, 100, 0); // move the canvas off screen;
    }

    public void Sell()
    {
        if(selectedTower != null)
        {
            FindObjectOfType<TowerManager>().gold += selectedTower.cost; // refund the tower cost
            selectedTower.tile.isOccupied = false; // reset the tile
            Destroy(selectedTower.gameObject); // destroy that tower
            selectedTower = null; // set this back to null
        }
        transform.position = new Vector3(100, 100, 0); // move the canvas off screen;
    }

    public void CloseUI()
    {
        selectedTower = null; // clear any tower that might have been selected
        transform.position = new Vector3(100, 100, 0); // move the canvas off screen;
    }
}
