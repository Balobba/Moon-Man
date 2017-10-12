using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBossSceneOnTrigger : MonoBehaviour { //This script is to change certain values before the bossfight.
    //Changes player movement speed, turns of oxygen decreasing, resets hp on player, spawns boss, moves camera back.

    private PlayerController playerCntrl;
    private PlayerHealthManager playerHealth;
    public Camera mainCamera;
    public GameObject boss;
    public GameObject bossSlider;


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

            
            mainCamera.GetComponent<CameraFollow>().cameraZoom = 1.5f; //zooms the camera out

            boss.SetActive(true);
            bossSlider.SetActive(true);



        }
    }


}
