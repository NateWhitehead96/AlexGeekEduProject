using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventButton : MonoBehaviour
{
    public GameObject[] bridgePlanks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(OpenBridge());
        }
    }

    IEnumerator OpenBridge()
    {
        for (int i = 0; i < bridgePlanks.Length; i++)
        {
            bridgePlanks[i].SetActive(true);
            yield return new WaitForSeconds(1);
        }
    }
}
