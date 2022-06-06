using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    public Slider soundFXSlider; // access to the slider
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundManager.instance.volume = soundFXSlider.value; // make the sound manager volume the same as the value on the slider
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
