using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAim : MonoBehaviour
{
    public List<GameObject> enemiesInRange;
    public float reloadSpeed;
    public float timer;
    public GameObject projectile; // tell us what projectile to use
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesInRange.Count <= 0) return; // stop code if no enemies are near

        if(timer >= reloadSpeed) // when the timer hits our reload time
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation); // creat the new projectile
            newProjectile.GetComponent<Projectile>().target = enemiesInRange[0].transform; // set the target for the projectile
            newProjectile.GetComponent<Projectile>().towerThatShot = this; // set the tower that shot to this gameobject
            newProjectile.GetComponent<Projectile>().damage = GetComponent<Tower>().damage; // assign damage from tower instead of toweraim
            timer = 0; // reset timer
        }
        timer += Time.deltaTime; // count up time

        Vector3 lookDirection = enemiesInRange[0].transform.position - transform.position; // find the look vector/direction
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f; // find our angle
        transform.rotation = Quaternion.Euler(0, 0, angle); // apply the angle
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            enemiesInRange.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            enemiesInRange.Remove(collision.gameObject);
        }
    }
}
