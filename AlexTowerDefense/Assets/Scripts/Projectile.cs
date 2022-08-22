using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    Arrow,
    LightningBolt,
    FireBlast,
    Cannon
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
    private List<GameObject> enemies; // list of enemies the bolt can bounce to

    private float timer;
    public LayerMask enemyLayer; // layer that all enemies will be on so our cannon blast can hurt them
    // Start is called before the first frame update
    void Start()
    {
        if(type == ProjectileType.LightningBolt)
        {
            enemies = towerThatShot.enemiesInRange; // assign the enemies near the tower to this list
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (type == ProjectileType.FireBlast) // if the projectile is a fireblast
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime); // shoot the fire forward
            timer += Time.deltaTime;
            if(timer >= towerThatShot.reloadSpeed) // when the tower is ready to shoot again
            {
                Destroy(gameObject); // destroy the fireball
            }
        }
        else // the type is anything but fireblast
        {
            if (target == null) // if the enemy has died before the arrow gets to it
            {
                target = transform; // assign it to itself
                Destroy(gameObject); // destroy the projectile
            }
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // movement for the arrow
        }
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
            if(type == ProjectileType.Cannon)
            {
                Collider2D[] enemiesInBlast = Physics2D.OverlapCircleAll(collision.transform.position, 1, enemyLayer); // find all enemies
                for (int i = 0; i < enemiesInBlast.Length; i++) // loop through all enemies
                {
                    enemiesInBlast[i].GetComponent<Enemy>().health -= damage; // each enemy will take the cannon's damage
                }
                Destroy(gameObject); // destroy the cannonball
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
                if(currentEnemy >= enemies.Count) // the bolt as hit the end of the list of enemies
                {
                    Destroy(gameObject); // destroy the bolt
                }
                else
                    target = enemies[currentEnemy].transform; // try to move to the next enemy
            }
            if(type == ProjectileType.FireBlast)
            {
                collision.gameObject.GetComponent<Enemy>().health -= damage; // deal its damage
            }
        }
    }
}
