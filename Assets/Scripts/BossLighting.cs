using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLighting : MonoBehaviour {


    public Camera lightingCamera;


    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.tag == "Player")
        {
            lightingCamera.backgroundColor = new Color(0.47f, 0.235f, 0.235f, 0f); //makes the game normal background lighting color
        }
    }
}
