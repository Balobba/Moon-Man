using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public Slider healthBar;
    public Text healthBarText;
    public PlayerHealthManager playerHealth;


    public Slider oxygenBar;
    public int oxygenValue;
    public float oxygenLossValue;


	// Use this for initialization
	void Start () {

        oxygenBar.maxValue = oxygenValue;
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        healthBarText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;



        oxygenBar.value -= oxygenLossValue;
        if(oxygenBar.value == 0)
        {
            playerHealth.playerCurrentHealth = 0;


        }


	}
}
