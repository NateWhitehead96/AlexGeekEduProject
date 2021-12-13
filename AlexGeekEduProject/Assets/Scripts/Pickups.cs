using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public int IncreasedBlockAmount; // how many blocks we give to the player

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerScript>().NumBouncyBlocks += IncreasedBlockAmount;
            other.gameObject.GetComponent<PlayerScript>().NumNormalBlocks += IncreasedBlockAmount;
            other.gameObject.GetComponent<PlayerScript>().NumPhysicsBlocks += IncreasedBlockAmount;
            FindObjectOfType<PickupManager>().SpawnNewPickup(transform.position.y + 3);
            Destroy(gameObject);
        }
    }
}
