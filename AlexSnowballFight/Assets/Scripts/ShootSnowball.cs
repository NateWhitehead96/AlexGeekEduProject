using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSnowball : MonoBehaviour
{
    public GameObject Snowball; // the prefab we want to spawn
    public GameObject PauseCanvas; // ref to the pause canvas
    public bool Paused;
    public bool Shooting;
    [SerializeField]
    public float ShootCooldown;
    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas.SetActive(false); // hides the canvas
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Paused == false && Shooting == false)
        {
            StartCoroutine(FireSnowball());
        }
        if (Input.GetKeyDown(KeyCode.Space)) // pause input using spacebar
        {
            PauseCanvas.SetActive(true);
            Paused = true;
            Time.timeScale = 0;
        }
    }

    IEnumerator FireSnowball()
    {
        Shooting = true;
        GameObject newSnowball = Instantiate(Snowball, transform.position, Quaternion.identity); // create the snowball
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // find our mouse position
        Vector3 shootDirection = mousePosition - transform.position; // find the vector between player and mouse
        newSnowball.GetComponent<SnowballScript>().MoveToPosition = new Vector3(shootDirection.x, shootDirection.y); // apply the movement to the snowball
        yield return new WaitForSeconds(ShootCooldown);
        Shooting = false;
    }
}
