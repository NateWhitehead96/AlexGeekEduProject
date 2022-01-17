using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type // type of powerup
{
    IncreaseShootSpeed,
    IncreaseSnowballSize,
    AddHealth
}

public class Powerup : MonoBehaviour
{
    public Type type; // the type of the powerup
    public float moveSpeed; // the move speed
    private SpriteRenderer sprite; // the sprite of the powerup

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        int x = Random.Range(0, 3);

        if (x == 0) // if the first type is chosen
        {
            type = Type.IncreaseShootSpeed;
            sprite.color = Color.green;
        }
        if (x == 1) // if the second type is chosen
        {
            type = Type.IncreaseSnowballSize;
            sprite.color = Color.cyan;
        }
        if (x == 2) // if the 3rd type is chosen
        {
            type = Type.AddHealth;
            sprite.color = Color.magenta;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y); // move to the left

        if(transform.position.x < -12) // if the powerup goes behind our player, destroy
        {
            Destroy(gameObject);
        }
    }
}
