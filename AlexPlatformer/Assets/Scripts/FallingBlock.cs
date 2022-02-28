using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public float shakeDuration; // how long the platform will shake
    public float shakeMagnitude; // how aggressive the platform will shake
    public float damping; // helps with slowing down the shake
    public float fallTime; // how long the platform will fall
    public Vector3 initialPosition; // hold what position the block starts at
    public bool falling; // to know if the block should fall or not
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position; // make sure whatever position the block is, is the initialposition
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeDuration > 0 && falling)
        {
            transform.position = initialPosition + Random.insideUnitSphere * shakeMagnitude; // shake code
            shakeDuration -= Time.deltaTime * damping; // slow the shake
        }
        if(shakeDuration <= 0 && falling)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1 * Time.deltaTime); // make the platform fall
            fallTime -= Time.deltaTime; // start counting down on fall time
        }

        if(fallTime <= 0) // reset the platform
        {
            falling = false;
            shakeDuration = 1;
            fallTime = 5;
            transform.position = initialPosition;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            falling = true;
        }
    }
}
