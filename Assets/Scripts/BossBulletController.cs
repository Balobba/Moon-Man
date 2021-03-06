﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : MonoBehaviour //Controlls the projectiles/bullets shot by the boss
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

        bulletDirection = direction;
        //Random.insideUnitCircle;
        //Debug.Log("bulletdirection: " + bulletDirection);

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

