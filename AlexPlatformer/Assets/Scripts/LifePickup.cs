using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerScript>())
        {
            GameManager.instance.Lives++; // increase lives by 1
            Destroy(gameObject);
        }
    }
}
