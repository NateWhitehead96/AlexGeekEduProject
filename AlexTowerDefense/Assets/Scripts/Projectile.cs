using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    Arrow,
    LightningBolt
}

public class Projectile : MonoBehaviour
{
    public Transform target; // targets position aka the enemy
    public float speed; // how fast it goes
    public int damage; // how much damage it does
    public ProjectileType type; // tell us what type this projectile is
    public TowerAim towerThatShot; // some access to the tower that shot this projectile

    // LightningBolt Helper variables
    private int currentEnemy = 0; // count up based on what enemy it's hitting

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) // if the enemy has died before the arrow gets to it
        {
            Destroy(gameObject); // destroy the projectile
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // movement for the arrow
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            if (type == ProjectileType.Arrow)
            {
                collision.gameObject.GetComponent<Enemy>().health -= damage; // deal the damage
                Destroy(gameObject); // destroy arrow
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            if (type == ProjectileType.LightningBolt)
            {
                collision.gameObject.GetComponent<Enemy>().health -= damage;
                currentEnemy++; // count up to go to the next enemy in the towers list of enemies
                if(currentEnemy >= towerThatShot.enemiesInRange.Count) // the bolt as hit the end of the list of enemies
                {
                    Destroy(gameObject); // destroy the bolt
                }
                target = towerThatShot.enemiesInRange[currentEnemy].transform; // try to move to the next enemy
            }
        }
    }
}
