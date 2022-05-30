using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathSystem : MonoBehaviour
{
    public PlayerScript player; // help with knowing if we are in the water or out
    public float maxBreath; // how much breath we have at the max
    public float currentBreath; // how much breath we have currently

    public Slider breathMeter; // access to slider for breath meter
    bool isDrowning; // to help know when the player is out of breath and underwater
    // Start is called before the first frame update
    void Start()
    {
        breathMeter.maxValue = maxBreath;
        currentBreath = maxBreath;
        player = GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.swimming == true)
        {
            currentBreath -= Time.deltaTime; // slowly subtract from our breath meter
            breathMeter.value = currentBreath; // set the value of the slider to our current breath
            breathMeter.gameObject.SetActive(true); // make sure the meter is visible
            // check if current breath is 0, then deal damage to player
            if(currentBreath <= 0 && isDrowning == false)
            {
                StartCoroutine(PlayerDrowning());
                currentBreath = 0; // to make sure current breath doesnt go under 0
            }
        }
        if(player.swimming == false)
        {
            currentBreath += 3 * Time.deltaTime; // regenerate our breath
            breathMeter.value = currentBreath; // set the value again
            if(currentBreath >= maxBreath) // if we're at max breath
            {
                currentBreath = maxBreath;
                breathMeter.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator PlayerDrowning()
    {
        isDrowning = true;
        player.PlayerHurt(); // player takes damage
        yield return new WaitForSeconds(4); // how long the player gets before taking more damage
        isDrowning = false;
    }
}
