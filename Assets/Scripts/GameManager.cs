using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    public float waitToReload;
    public GameObject thePlayer;


    public GameObject pauseScreen;
    public GameObject HUD;
    private bool paused;

    private int tempHP;
    private float tempOxygen;

    public int gameOverIndex;

    void Start()
    {
       // thePlayer.GetComponent<PlayerHealthManager>();

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


    public void GameOver()
    {
        
        waitToReload -= Time.deltaTime;
        if (waitToReload < 0)
        {
            Debug.Log("INNE I GAME OVER IF");
            
            SceneManager.LoadScene(gameOverIndex);
            thePlayer.SetActive(true);
            

            //Application.LoadLevel(Application.loadedLevel); //reloads the level and spawns player where he started
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //another way to to the same thing (loading the scene instead)
            
        }

    }


    public void RevivePlayer() //temporary function for reviving player in the same scene
    {
        waitToReload -= Time.deltaTime;
        if (waitToReload < 0)
        {
            thePlayer.SetActive(true);
            Debug.Log("INNE I REVIVE!");

            //Application.LoadLevel(Application.loadedLevel); //reloads the level and spawns player where he started
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //another way to to the same thing (loading the scene instead)
            
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
