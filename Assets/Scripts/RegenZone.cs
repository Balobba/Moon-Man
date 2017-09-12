using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenZone : MonoBehaviour
{

    public PlayerHealthManager playerHealth;


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            //ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

            playerHealth.RegenerateOxygenandHealth();

        }
    }





    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
