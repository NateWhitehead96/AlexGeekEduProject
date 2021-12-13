using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public GameObject Pickup; // the prefab pickup we want to spawn
    public GenerateMap map; // reference to the map generator

    public int InitialAmountOfPickups;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < InitialAmountOfPickups; i++)
        {
            int x = Random.Range(0, map.Rows); // a random spot on the x axis of our map
            int z = Random.Range(0, map.Cols); // a random spot on the z axis of our map
            // int y will be anything higher than the maps layer. anything higher than map.layers
            Instantiate(Pickup, new Vector3(x, map.Layers + i, z), Quaternion.identity); // this will spawn the pickup
        }
    }

    public void SpawnNewPickup(float height)
    {
        int x = Random.Range(0, map.Rows);
        int z = Random.Range(0, map.Cols);
        Instantiate(Pickup, new Vector3(x, height, z), Quaternion.identity);
    }
}
