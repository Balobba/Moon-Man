using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float waitToReload;
    public GameObject thePlayer;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
   

    }


    public void RevivePlayer()
    {
        waitToReload -= Time.deltaTime;
        if (waitToReload < 0)
        {
            //Application.LoadLevel(Application.loadedLevel); //reloads the level and spawns player where he started
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //another way to to the same thing (loading the scene instead)
            thePlayer.SetActive(true);
        }

    

         /*if (reloading)
         {
             waitToReload -= Time.deltaTime;
             if (waitToReload < 0)
             {
                 //Application.LoadLevel(Application.loadedLevel); //reloads the level and spawns player where he started
                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //another way to to the same thing (loading the scene instead)
                 thePlayer.SetActive(true);
             }

         }

        /*

         if (other.gameObject.name == "Player")
         {
             //Destroy(other.gameObject);
             other.gameObject.SetActive(false);
             reloading = true;
             thePlayer = other.gameObject;
         }*/


    }
}
