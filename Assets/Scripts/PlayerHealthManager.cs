using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour { //Keeps track of the players max health and current health

    public int playerMaxHealth;
    public int playerCurrentHealth;
    public int healthRegenValue;


    public float playerMaxOxygen;
    public float playerCurrentOxygen;
    public float oxygenLossValue;
    public float oxygenRegenValue;

    // Use this for initialization
    void Start () {

        playerCurrentHealth = playerMaxHealth;
        playerCurrentOxygen = playerMaxOxygen;
		
	}
	
	// Update is called once per frame

	void Update () {

        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);

        }


        OxygenLoss();

    }


    public void OxygenLoss()
    {
        playerCurrentOxygen -= oxygenLossValue;

        if (playerCurrentOxygen <= 0)
        {
            playerCurrentHealth = 0; //Player dies
            //gameObject.SetActive(false);
        }

    }

    public void RegenerateOxygenandHealth()
    {
        if (playerCurrentOxygen < playerMaxOxygen) {

            playerCurrentOxygen += oxygenRegenValue;
        }


        if (playerCurrentHealth < playerMaxHealth)
        {
            playerCurrentHealth += healthRegenValue;
        }
        
    }


    public void HurtPlayer(int damageToPlayer) //Is called when an enemy collides with the player (from HurtPlayer script)
    {
        playerCurrentHealth -= damageToPlayer;

    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;

    }

}
