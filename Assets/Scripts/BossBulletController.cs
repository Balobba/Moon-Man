using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : MonoBehaviour
{

    private Rigidbody2D rbody;
    public float speed; 
    Vector2 direction;
    Vector2 bulletDirection;
    public int bulletDamage;
    public int surviveTime;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {


        rbody.AddForce(bulletDirection * speed);

        Destroy(gameObject, surviveTime);



    }

    public void SetDirection(Vector2 direction)
    {

        bulletDirection = Random.insideUnitCircle; 
        Debug.Log("bulletdirection: " + bulletDirection);
        //bulletDirection = Vector2.down; //MAYBE AN ALTERNATIVE

    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        //add give damage to player!

        if (other.gameObject.tag == "Player")
        {

            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(bulletDamage);

            Destroy(gameObject);

        }


    }

}

