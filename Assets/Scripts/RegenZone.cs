using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenZone : MonoBehaviour //This script is used in a trigger box to regenerate the players hp.
{

    public PlayerHealthManager playerHealth;


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
           
            playerHealth.RegenerateOxygenandHealth();

        }
    }
    

    // Use this for initialization
    void Start()
    {
      //  playerHealth = GetComponent<PlayerHealthManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
