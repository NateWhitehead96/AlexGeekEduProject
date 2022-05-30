using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float moveSpeed;
    public float timer;
    public ParticleSystem bubblePop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // let the bubble float up for 3 seconds then destroy
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime); // make the bubble go in it's "up direction" based on rotation
        if(timer >= 3)
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BreathSystem>())
        {
            // full restore the breath
            collision.gameObject.GetComponent<BreathSystem>().currentBreath = collision.gameObject.GetComponent<BreathSystem>().maxBreath;
            StartCoroutine(ShowPop());
        }
    }

    IEnumerator ShowPop()
    {
        GetComponent<SpriteRenderer>().enabled = false; // hide the sprite
        moveSpeed = 0; // stop the bubble from moving
        GetComponent<CircleCollider2D>().enabled = false; // make sure player cant collide with this again
        bubblePop.Play(); // play the particle effect
        yield return new WaitForSeconds(3);
        Destroy(gameObject); // destroy the bubble
    }
}
