using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour
{
    public Vector3 MoveToPosition; // our mouse position the ball will move to
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveToPosition * Time.deltaTime);

        if(transform.position.x > 12 || transform.position.y > 6 || transform.position.y < -6) // if the snowball goes off screen, destory it
        {
            Destroy(gameObject);
        }
    }
}
