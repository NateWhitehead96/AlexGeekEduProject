using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSnowball : MonoBehaviour
{
    public GameObject Snowball; // the prefab we want to spawn
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newSnowball = Instantiate(Snowball, transform.position, Quaternion.identity); // create the snowball
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // find our mouse position
            Vector3 shootDirection = mousePosition - transform.position; // find the vector between player and mouse
            newSnowball.GetComponent<SnowballScript>().MoveToPosition = new Vector3(shootDirection.x, shootDirection.y); // apply the movement to the snowball
        }
    }
}
