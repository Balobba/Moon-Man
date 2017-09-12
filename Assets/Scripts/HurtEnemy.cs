using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour //This script is attatched to any weapon that the player is carrying
{

    //public CircleCollider2D enemyBody;


    public int damageToGive;
    public GameObject damageBurst;
    public Transform hitPoint;

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
            if (other.gameObject.tag == "Enemy")
            {
            //Destroy(other.gameObject); //Kills it
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
        }
        
        



    }
}
