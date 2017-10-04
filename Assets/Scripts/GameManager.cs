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

    private VolumeController theVC;//IF I FEEL LIKE SOLVING THE MUSIC BUG

    public static bool gmExists;

    public bool isGameOver;


    void Start()
    {
      /*  {
            if (!gmExists)
            {
                gmExists = true;
                DontDestroyOnLoad(transform.gameObject);

            }
            else
            {
                Destroy(gameObject);
            }

        }
        */

        // thePlayer.GetComponent<PlayerHealthManager>();
        //DontDestroyOnLoad(pauseScreen); //This makes the user be able to pause between scenes
        theVC = GetComponent<VolumeController>(); //IF I FEEL LIKE SOLVING THE MUSIC BUG
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(1);

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
        if (!isGameOver)
        {
            isGameOver = true;


        }
        
        waitToReload -= Time.deltaTime;
        if (waitToReload < 0)
        {
            
            
            isGameOver = false;
            thePlayer.SetActive(false);
            
            SceneManager.LoadScene(gameOverIndex);

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
