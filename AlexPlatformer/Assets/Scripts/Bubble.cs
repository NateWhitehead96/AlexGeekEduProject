using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float moveSpeed;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // let the bubble float up for 3 seconds then destroy
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        if(timer >= 3)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BreathSystem>())
        {
            // full restore the breath
            collision.gameObject.GetComponent<BreathSystem>().currentBreath = collision.gameObject.GetComponent<BreathSystem>().maxBreath;
            Destroy(gameObject); // destroy the bubble
        }
    }
}
