using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessController : MonoBehaviour {

    public Camera lightingCamera;


    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            lightingCamera.backgroundColor = new Color(0f, 0f, 0f, 5f); //makes the game pitch black
        }
    }
}
