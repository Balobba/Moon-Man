using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ //The script that controlls all UI displayed


    public Slider healthBar;
    public Text healthBarText;
    public PlayerHealthManager playerHealth;

    public Slider oxygenBar;
    public Text oxygenBarText;

    private float flashCounterOxygenText;
    public float flashLengthOxygenLength;
    public float flashSpeedOxygenText;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        healthBarText.text = "HP: " + Mathf.Round(playerHealth.playerCurrentHealth) + "/" + Mathf.Round(playerHealth.playerMaxHealth);

        oxygenBar.value = playerHealth.playerCurrentOxygen; //Updates the oxygenbar according to the players oxygen level
        if (oxygenBar.value <= 0)
        {

            //temporary solution to flashing text
            oxygenBarText.color = new Color(oxygenBarText.color.r,Mathf.PingPong( 255, Time.time *flashSpeedOxygenText ),Mathf.PingPong(255, Time.time * flashSpeedOxygenText), oxygenBarText.color.a);

        }
        else
        {
            oxygenBarText.color = new Color(oxygenBarText.color.r, 255f, 255f, oxygenBarText.color.a);

        }



    }


    }

