using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseController : MonoBehaviour {

    private Rigidbody2D rbody;
    private Animator anim;

    private Vector2 moveDirection;

    public CircleCollider2D territory;
        bool playerInTerritory;
        public Transform target;
        public float speed;
        public float distanceToTarget;

        

    // Use this for initialization
    void Start()
        {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerInTerritory = false;
        }

   void OnTriggerStay2D(Collider2D other) //Everything that happens inside circle
    {
        if(other.gameObject.tag == "Player")
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



    // Update is called once per frame
    void Update()
    {
            if (playerInTerritory)
            {
            //Debug.Log("inside circle");
            MoveToPlayer();


            }else
            {
            anim.SetBool("is_walking", false);
            rbody.velocity = Vector2.zero;

            //Debug.Log("outside circle");


        }

            

    }

}