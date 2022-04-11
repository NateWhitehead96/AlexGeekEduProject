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
        LoadGame(); // when we start the game load our save
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Lives", Lives); // save whatever amount of lives we have, to our computer and save it under the name Lives
        PlayerPrefs.SetInt("Levels", LevelsBeaten); // save the levels we've beaten
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("Lives")) // check if we have saved before
        {
            Lives = PlayerPrefs.GetInt("Lives"); // when we load the game, set our lives to be this number that was saved
            LevelsBeaten = PlayerPrefs.GetInt("Levels"); // load the levels we've beaten
        }
    }
}
