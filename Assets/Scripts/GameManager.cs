using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float waitToReload;
    public GameObject thePlayer;


    public GameObject pauseScreen;
    public GameObject HUD;
    private bool paused;

    private int tempHP;
    private float tempOxygen;

    void Start()
    {
        

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!paused)
            {
                PauseGame();
                
            }
            else
            {

                ResumeGame();
            }

        }
    }

    private void PauseGame()
    {
        paused = true;
        pauseScreen.SetActive(true);
        HUD.SetActive(false);

        Time.timeScale = 0;

    }


    public void ResumeGame()
    {
        paused = false;
        pauseScreen.SetActive(false);
        HUD.SetActive(true);

        Time.timeScale = 1;


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
