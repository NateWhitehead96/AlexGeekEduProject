using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // the instance we use to play the sounds

    private void Awake() // singleton pattern to make sure only 1 sound manager is in our game
    {
        if(instance != null) // if there is already a sound manager
        {
            Destroy(gameObject); // destroy the sound manager in the level
        }
        else
        {
            instance = this; // make the sound manager this game object
            DontDestroyOnLoad(gameObject); // allows it to travel between scenes
        }
    }

    private void Start()
    {
        hurt.playOnAwake = false; // this will force the hurt sound effect to not play
    }
    // all of the sound effects
    public AudioSource pickup;
    public AudioSource hurt;
    public AudioSource jump;
}
