using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private Rigidbody2D rbody;
    public int speed; //4 is good for now
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
        direction = direction.normalized;
        Debug.Log("direction: " + direction);
        //Debug.Log("angle: " + Vector2.Angle(direction, Vector2.zero));


        if (Vector2.Angle(direction, Vector2.up) <= 45.0)
        {
            bulletDirection = Vector2.up;
            //rbody.AddForce(Vector2.up *speed);
            Debug.Log("North");
        }
        else if (Vector2.Angle(direction, Vector2.right) <= 45.0)
        {
            bulletDirection = Vector2.right;
            Debug.Log("East");
        }
        else if (Vector2.Angle(direction, Vector2.down) <= 45.0)
        {
            bulletDirection = Vector2.down;
            Debug.Log("South");
        }
        else
        {
            bulletDirection = Vector2.left;
            Debug.Log("West");
        }

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
