using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables; // gives access to using the timeline director

public class BossScript : MonoBehaviour
{
    public GameObject[] HealthChunks; // holds all of the health chunks
    public int health; // how much health the boss has
    public BoxCollider2D hitBox; // the jewel on bosses head

    // shake variables
    public float shakeDuration; // how long it will shake
    public float shakeMagnitude; // how aggressive the hsake will be
    public float damping; // helps with slowing down the shake
    public Vector3 initialPosition; // the start position for the head

    public PlayableDirector director; // the final cutscene director
    bool inCutscene;
    // Start is called before the first frame update
    void Start()
    {
        hitBox = GetComponent<BoxCollider2D>();
        initialPosition = transform.position; // assign its start position
        director = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (director.state != PlayState.Playing && inCutscene == true)
        {
            // destroy boss and hands or disable them
            Destroy(gameObject);
        }
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude; // add random movement to its position
            shakeDuration -= Time.deltaTime * damping; // slow down and stop the shaking
        }

        if(health == 4)
        {
            HealthChunks[0].SetActive(false);
        }
        if (health == 3)
        {
            HealthChunks[1].SetActive(false);
        }
        if (health == 2)
        {
            HealthChunks[2].SetActive(false);
        }
        if (health == 1)
        {
            HealthChunks[3].SetActive(false);
        }
        if (health == 0)
        {
            HealthChunks[4].SetActive(false);
            FindObjectOfType<BossTrigger>().BossDefeated(); // this hides some stuff when the boss dies
            director.Play(); // now play the animation
            inCutscene = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerScript>())
        {
            StartCoroutine(DamageBoss());
        }
    }

    IEnumerator DamageBoss()
    {
        shakeDuration = 1; // set the shake duration
        health--; // decrease health
        hitBox.enabled = false; // make sure player can spam damage on boss
        yield return new WaitForSeconds(2);
        hitBox.enabled = true; // bring back hitbox for the player
    }
}
