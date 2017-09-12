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

    private bool flashing;
    public float flashLenght;
    private float flashCounter;
    private SpriteRenderer playerSprite;

    //private GameManager game;

    // Use this for initialization
    void Start () {

        playerCurrentHealth = playerMaxHealth;
        playerCurrentOxygen = playerMaxOxygen;
        playerSprite = GetComponent<SpriteRenderer>();
        //game = GetComponent<GameManager>();
		
	}
	
	// Update is called once per frame

	void Update () {

        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            //game.RevivePlayer();
            

        }

        OxygenLoss();

        if (flashing)
        {
            if (flashCounter > flashLenght * 0.66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);

            }else if(flashCounter > flashCounter * 0.33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);

            }
            else if (flashCounter > flashLenght * 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashing = false;
            }
            flashCounter -= Time.deltaTime;
        }

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
        flashing = true;
        flashCounter = flashLenght;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;

    }

}
