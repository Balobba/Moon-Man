using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeSceneOnClick : MonoBehaviour
{

    public GameManager gameManager;

    private void Start()
    {
        gameManager.GetComponent<GameManager>();

    }



    public void ResumeGame()
    {
        gameManager.ResumeGame();
    }

    /* public void ResumeByIndex(int sceneIndex)
     {
         //SceneManager.LoadScene(sceneIndex);
         //SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
     }*/

}
