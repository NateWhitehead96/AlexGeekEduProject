using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisiblock : MonoBehaviour
{
    public SpriteRenderer sprite;
    public BoxCollider2D box;
    public float timer;
    public float visibitlyTime;
    public bool invisible;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= visibitlyTime)
        {
            if(invisible == true) // if the block is visible
            {
                invisible = false;
                sprite.enabled = true;
                box.enabled = true;
            }
            else if (invisible == false)
            {
                invisible = true;
                sprite.enabled = false;
                box.enabled = false;
            }
            timer = 0;
        }
    }
}
