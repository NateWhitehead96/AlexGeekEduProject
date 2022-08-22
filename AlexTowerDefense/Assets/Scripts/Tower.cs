using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int cost; // how much it costs
    public Tile tile; // to know what tile this tower is on

    public UpgradeSellCanvas canvas; // every tower will have access to this canvas
    public int damage; // damage is on this script instead
    // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<UpgradeSellCanvas>(); // assign the canvas
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (canvas.selectedTower == null) // only if a tower wasn't selected show the canvas
        {
            canvas.selectedTower = this; // assign this tower we select to the canvas
            canvas.transform.position = transform.position + new Vector3(0, 1, 0); // overlap this canvas on our tower, with small offset to move it up
        }
    }
}
