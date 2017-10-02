using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBossSceneOnTrigger : MonoBehaviour {

    private PlayerController playerCntrl;
    private PlayerHealthManager playerHealth;


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {

            

            playerCntrl = other.gameObject.GetComponent<PlayerController>();
            playerHealth = other.gameObject.GetComponent<PlayerHealthManager>();

            //Changes certain player values for the bossfight

            playerCntrl.playerMovementSpeed = playerCntrl.playerMovementSpeed * 1.5f; //Increases player movementspeed in bossfight
            playerHealth.oxygenLossValue = 0f; //Stops decreasing of oxygen
            playerHealth.SetMaxHealth(); //fills up health to max
            

            DontDestroyOnLoad(other.gameObject); //Doesn't destroy the player when loading into another scene
            
            LoadByIndex(4); //Loading boss stage
        }
    }


    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);


    }

}
