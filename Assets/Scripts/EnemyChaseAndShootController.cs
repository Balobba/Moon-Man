using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseAndShootController : MonoBehaviour //Applied to enemies that chase the player a certain distance, and fires bullets. In this case the tank
{

    private Rigidbody2D rbody;
    private Animator anim;

    private Vector2 moveDirection;

    public CircleCollider2D territory;
    bool playerInTerritory;
    public Transform target; //the player target
    public float speed;
    public float distanceToTarget;

    public GameObject EnemyBullet;
    public Transform cannonPosition;


    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerInTerritory = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Invoke("FireEnemyBullet", 1f);

        }


    }

   
    void OnTriggerStay2D(Collider2D other) //Everything that happens inside circle
    {
        if (other.gameObject.tag == "Player")
        {
            playerInTerritory = true;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInTerritory = false;
        }
    }

    void MoveToPlayer()
    {
        if (Vector3.Distance(transform.position, target.position) > distanceToTarget)
        {
            Vector2 moveDirection = new Vector2((transform.position.x - target.position.x) * speed, (transform.position.y - target.position.y) * speed);
            rbody.velocity = -moveDirection; //walking towards target

            anim.SetBool("is_walking", true);
            anim.SetFloat("input_x", -moveDirection.x);
            anim.SetFloat("input_y", -moveDirection.y);

        }


    }

    void FireEnemyBullet()
    {
        //GameObject player = GameObject.Find("Player");
        
        GameObject bullet = Instantiate(EnemyBullet, cannonPosition.position, cannonPosition.rotation);
        //bullet.transform.position = cannonPosition.position;
        Vector2 direction = target.transform.position - bullet.transform.position;
        bullet.GetComponent<BulletController>().SetDirection(direction);

    }



    // Update is called once per frame
    void Update()
    {

        //Debug.Log("distanse to target: " + Vector3.Distance(transform.position, target.position));
        if (playerInTerritory)
        {
            //Debug.Log("inside circle");
            MoveToPlayer();

            if(Vector2.Distance(transform.position, target.position) < distanceToTarget)
            {
                //Vector2 moveDirection = new Vector2((transform.position.x - target.position.x) * 0.01f, (transform.position.y - target.position.y) * 0.01f);
                //rbody.velocity = -moveDirection;
                rbody.velocity = Vector2.zero;
                
                Invoke("FireEnemyBullet", 1f);

            }
            



        }
        else
        {
            anim.SetBool("is_walking", false);
            rbody.velocity = Vector2.zero;

            //Debug.Log("outside circle");


        }



    }

}