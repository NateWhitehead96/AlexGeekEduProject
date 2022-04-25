using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool activated; // just to know if the player has reached this checkpoint or not
    public ParticleSystem fireWorks; // the effect to play when we pass the checkpoint

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && activated == false)
        {
            PlayerScript player = collision.gameObject.GetComponent<PlayerScript>(); // now we have access to the player to change hp and checkpoint
            player.Checkpoint = transform; // make the player spawn at this checkpoint
            PlayerScript.Health = 3; // max heal the player
            fireWorks.Play(); // play the particle effects
            activated = true;
        }
    }
}
