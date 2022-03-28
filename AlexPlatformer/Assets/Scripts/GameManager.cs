using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // the is the instance of the game manager

    public int LevelsBeaten; // how many, or which level we've beaten
    public int Lives = 3;
    private void Awake() // singleton design pattern
    {
        if(instance != null) // if we already have a instance
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this; // we dont have an instance, make this gameobject the game manager
            DontDestroyOnLoad(gameObject); // this will allow the gamemanger to go between scenes
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
