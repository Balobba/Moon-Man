using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour { //The script that controlls all UI displayed


    public Slider healthBar;
    public Text healthBarText;
    public PlayerHealthManager playerHealth;
    


    public Slider oxygenBar;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        healthBarText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;

        oxygenBar.value = playerHealth.playerCurrentOxygen; //Updates the oxygenbar according to the players oxygen level


    }


}
