using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject wall1, wall2; // both of our walls to keep the player inside the boss arena
    public GameObject bossCanvas; // access to boss canvas

    // Start is called before the first frame update
    void Start()
    {
        // hide some gameobjects
        wall1.SetActive(false);
        wall2.SetActive(false);
        bossCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerScript>())
        {
            // show game objects
            wall1.SetActive(true);
            wall2.SetActive(true);
            bossCanvas.SetActive(true);
        }
    }

    public void BossDefeated() // when the boss is defeated we can hide some stuff
    {
        wall1.SetActive(false);
        wall2.SetActive(false);
        bossCanvas.SetActive(false);
    }
}
