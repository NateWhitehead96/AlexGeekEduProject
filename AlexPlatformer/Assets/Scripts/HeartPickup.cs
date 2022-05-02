using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public float growingSpeed; // how fast it grows and shrinks
    public float size; // how big the sprite is
    public float maxSize;
    public float minSize;
    public int direction; // to know if its growning or shrinking
    
    // Start is called before the first frame update
    void Start()
    {
        maxSize = size + 0.5f; // make sure maxsize is 0.5 pixels bigger
        minSize = size - 0.5f; // make sure minsize is 0.5 pixels smaller
    }

    // Update is called once per frame
    void Update()
    {
        size += direction * growingSpeed * Time.deltaTime;
        transform.localScale = new Vector3(size, size);

        if(transform.localScale.x >= maxSize)
        {
            direction = -1;
        }
        if(transform.localScale.x <= minSize)
        {
            direction = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerScript.Health++;
            if(PlayerScript.Health > 3)
            {
                PlayerScript.Health = 3; // this is to make sure we never exceed max health
            }
            Destroy(gameObject);
        }
    }
}
