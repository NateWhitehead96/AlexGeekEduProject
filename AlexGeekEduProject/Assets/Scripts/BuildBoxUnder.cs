using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBoxUnder : MonoBehaviour
{
    public GameObject Cube;
    // Start is called before the first frame update
    void Start()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 100)) // shoot a ray cast down to see if there is ground
        {
            if (hit.collider.CompareTag("Cube")) // if there is ground spawn a new cube under the cube
            {
                Instantiate(Cube, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
            }
        }
    }
}
