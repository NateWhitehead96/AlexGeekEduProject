using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Path path; // access to the path and its checkpoints
    public int currentPoint; // what point the enemy is moving towards
    public int health; // health
    public float speed; // how fast it moves
    public Slider healthBar; // floating health bar above our enemies
    // Start is called before the first frame update
    void Start()
    {
        path = FindObjectOfType<Path>(); // set path to the game path
        healthBar.maxValue = health; // set the max health
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = health; // update the slider value with the health
        // move towards the current checkpoint
        transform.position = Vector3.MoveTowards(transform.position, path.checkpoints[currentPoint].position, speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, path.checkpoints[currentPoint].position); // find distance to next point
        if(distance <= 0.05f) // when the enemy is pretty much on the checkpoint
        {
            currentPoint++; // increase the current point by 1 so it moves to the next check point
        }
        if(currentPoint >= path.checkpoints.Length) // reached end of the map, kill enemy off
        {
            FindObjectOfType<TowerManager>().lives--; // subtract a life when an enemy reaches the end
            Destroy(gameObject);
        }
        if(health <= 0)
        {
            FindObjectOfType<TowerManager>().gold += 5; // give the player gold on kill
            Destroy(gameObject); // kill enemy
        }
    }
}
