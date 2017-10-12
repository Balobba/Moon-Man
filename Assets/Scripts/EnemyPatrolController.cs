using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolController : MonoBehaviour { //Applied to the enemies that don't chase the player. Instead patrols in a random direction and pace.

    private Rigidbody2D rbody;
    private Animator anim;

    public float moveSpeed;
    
    private bool moving;
    public float timeBetweenMove;
    public float timeToMove;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;

    private Vector2 moveDirection;


	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f); //adds randomness to enemies movement
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

    }
	
	// Update is called once per frame
	void Update () {
		if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            rbody.velocity = moveDirection;

            anim.SetBool("is_walking", true);
            anim.SetFloat("input_x", moveDirection.x);
            anim.SetFloat("input_y", moveDirection.y);

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                anim.SetBool("is_walking", false);
                //timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }

        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;

            rbody.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0)
            {
                moving = true;
                //timeToMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                moveDirection = new Vector2(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed);
            }
        }



	}


}
