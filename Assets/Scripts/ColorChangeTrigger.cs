using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeTrigger : MonoBehaviour
{

    public Camera lightingCamera;
    public Transform teleportENDBOSS;
    private float distance;
    public Transform player;


    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.transform.tag == "Player")
        {

            distance = player.position.x - teleportENDBOSS.position.x;
            lightingCamera.backgroundColor = new Color((5 * 0.082f) / Mathf.Abs(distance), 0.082f, 0.082f, 5f);
        }

    }

}
