using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour { //DO ALL BOSS SEQUENCES HERE (MOVEMENT)

    Rigidbody2D rbody;
    Animator anim;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;
    public float bossMovementSpeed;


    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
