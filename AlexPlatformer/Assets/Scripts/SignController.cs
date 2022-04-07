using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignController : MonoBehaviour
{
    public GameObject DisplayCanvas;
    // Start is called before the first frame update
    void Start()
    {
        DisplayCanvas.SetActive(false); // hide the text and canavs
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DisplayCanvas.SetActive(true); // show the text
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DisplayCanvas.SetActive(false); // hide the text
        }
    }
}
