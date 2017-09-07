using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    //public CircleCollider2D enemyBody;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
                if(other.gameObject == enemyBody)
                {
                    Destroy(other.gameObject); //FUNKAR INTE JUST NU

                }
                */

        
            if (other.tag == "Enemy")
            {
                Destroy(other.gameObject); //Kills it


            }
        
        



    }
}
