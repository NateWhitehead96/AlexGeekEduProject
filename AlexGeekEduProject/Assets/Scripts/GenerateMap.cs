using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public GameObject Cube;
    public int Cols;
    public int Rows;
    public int Layers;
    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    void Generate()
    {
        // first layer of the map
        for (int i = 0; i < Cols; i++) // cycle through all colums
        {
            for(int j = 0; j < Rows; j++) // cycle through all rows
            {
                Instantiate(Cube, new Vector3(transform.position.x + 1 * i, transform.position.y, transform.position.z + 1 * j), Quaternion.identity); // spawn the cube
            }
        }

        // creating addtional layers
        for(int a = 0; a < Layers; a++)
        {
            for (int i = 0; i < Cols; i++) // cycle through all colums
            {
                for (int j = 0; j < Rows; j++) // cycle through all rows
                {
                    int RandomBlock = Random.Range(0, 20);
                    if(RandomBlock == 0)
                    {
                        Instantiate(Cube, new Vector3(transform.position.x + 1 * i, transform.position.y + 1 * a, transform.position.z + 1 * j), Quaternion.identity); // spawn the cube
                    }
                }
            }
        }
    }
}
