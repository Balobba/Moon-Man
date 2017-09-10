using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rbody;
    Animator anim;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;


	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (!attacking)
        {




            float playermovementspeed = 3; //the speed of the player character (3 is good for now)
            Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (movement_vector != Vector2.zero)
            {
                anim.SetBool("is_walking", true);
                anim.SetFloat("input_x", movement_vector.x);
                anim.SetFloat("input_y", movement_vector.y);
            }
            else
            {
                anim.SetBool("is_walking", false);
            }

            rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
            //Debug.Log(Time.deltaTime);



            if (Input.GetKeyDown(KeyCode.J))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                rbody.velocity = Vector2.zero; //stops moving the character
                anim.SetBool("is_attacking", true);



            }

        }

        if(attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;

        }

        if(attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("is_attacking", false);
            //attackTimeCounter = attackTime;

        }




    }
}
