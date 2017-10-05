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

    public Transform[] spots;
    public Transform projectileSource;

    public GameObject projectile;

    public Transform target; //TESTING


    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        StartCoroutine("BossSequence");

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void FireBullets()
    {

        GameObject bullet = Instantiate(projectile, projectileSource.position, projectileSource.rotation);
        float randomX = Random.Range(0, 360);
        float randomY = Random.Range(0, 360);

        Vector2 randomDir = new Vector2(randomX, randomY);

        Vector2 direction = target.transform.position - bullet.transform.position;
        bullet.GetComponent<BossBulletController>().SetDirection(randomDir);

        Debug.Log("INSIDE FIREBULLETS!");

    }


    IEnumerator BossSequence()
    {

        //FIRST ATTACK

        while (transform.position != spots[0].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[0].position.x, spots[0].position.y), bossMovementSpeed); //moves towards the location


            yield return null;

        }

        yield return new WaitForSeconds(1f);
        Invoke("FireBullets", 2f);
        yield return new WaitForSeconds(1f);
        Invoke("FireBullets", 2f);
        yield return new WaitForSeconds(1f);
        Invoke("FireBullets", 2f);
        yield return new WaitForSeconds(1f);
        Invoke("FireBullets", 2f);
        yield return new WaitForSeconds(1f);
        Invoke("FireBullets", 2f);
        Invoke("FireBullets", 2f);
        Invoke("FireBullets", 2f);
        Invoke("FireBullets", 2f);
        Invoke("FireBullets", 2f);
        Invoke("FireBullets", 2f);





        yield return null;


    }
}
