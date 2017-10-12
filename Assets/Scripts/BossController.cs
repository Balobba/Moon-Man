using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour { //The sequence (movement) script for the boss

    Rigidbody2D rbody;
    Animator anim;

    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;
    public float bossMovementSpeed;

    public Transform[] spots;
    public Transform projectileSourceBlue;
    public Transform projectileSourceRed;

    public GameObject projectile;
    public GameObject projectileRed;
    public GameObject[] enemies;

    public Transform target; //TESTING. IS GOING TO BE PLAYER LATER!


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

        GameObject bullet = Instantiate(projectile, projectileSourceBlue.position, projectileSourceBlue.rotation);
        //float randomX = Random.Range(0, 360);
        //float randomY = Random.Range(0, 360);

        //Vector2 randomDir = new Vector2(randomX, randomY);
        Vector2 randomDir = Random.insideUnitCircle;

        //Vector2 direction = target.transform.position - bullet.transform.position;
        bullet.GetComponent<BossBulletController>().SetDirection(randomDir);

    }


    void FireRedBullets()
    {

        GameObject bullet = Instantiate(projectileRed, projectileSourceRed.position, projectileSourceRed.rotation);

        Vector2 direction = target.transform.position - bullet.transform.position;
        bullet.GetComponent<BossBulletController>().SetDirection(direction);

        //Debug.Log("INSIDE FIREBULLETS!");

    }

    void SpawnEnemies() //spawns 4 worms (for now) enemies around the player. Can be modified
    {
        //int randomEnemy0 = Random.Range(0,3);
        //int randomEnemy1 = Random.Range(0, 3);
        //int randomEnemy2 = Random.Range(0, 3);
        //int randomEnemy3 = Random.Range(0, 3);
        GameObject enemy0 = Instantiate(enemies[2], new Vector3(target.position.x - 0.5f, target.position.y), Quaternion.identity);
        GameObject enemy1 = Instantiate(enemies[2], new Vector3(target.position.x + 0.5f, target.position.y), Quaternion.identity);
        GameObject enemy2 = Instantiate(enemies[2], new Vector3(target.position.x, target.position.y + 0.5f), Quaternion.identity);
        GameObject enemy3 = Instantiate(enemies[2], new Vector3(target.position.x, target.position.y - 0.5f), Quaternion.identity);

    }



    IEnumerator BossSequence()
    {
        anim.SetBool("is_walking", true);
        //FIRST ATTACK
        while (transform.position != spots[0].position)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[0].position.x, spots[0].position.y), bossMovementSpeed); //moves towards the location
            
           

            yield return null;

        }
        anim.SetBool("is_walking", false);
        anim.SetBool("is_attacking", true);

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
        yield return new WaitForSeconds(4f);
        anim.SetBool("is_attacking", false);


        //SECOND ATTACK
        anim.SetBool("is_walking", true);
        

        while (transform.position != spots[1].position)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[1].position.x, spots[1].position.y), bossMovementSpeed); //moves towards the location

           

            yield return null;

        }
        anim.SetBool("is_walking", false);
        anim.SetBool("is_attacking", true);

        Invoke("FireRedBullets", 2f);
        yield return new WaitForSeconds(4f);
        Invoke("FireRedBullets", 2f);
        yield return new WaitForSeconds(4f);
        anim.SetBool("is_attacking", false);

        //THIRD ATTACK (SPAWN ENEMIES)
        anim.SetBool("is_walking", true);

        while (transform.position != spots[2].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[2].position.x, spots[2].position.y), bossMovementSpeed * 4); //moves towards the location
            //transform.position = spots[2].transform.position;



            yield return null;

        }
        anim.SetBool("is_walking", false);

        anim.SetBool("is_attacking", true);

        Invoke("SpawnEnemies", 1f);
        yield return new WaitForSeconds(6f);
        anim.SetBool("is_attacking", false);

        //FOURTH ATTACK (STANDING STILL)
        anim.SetBool("is_walking", true);
        while (transform.position != spots[3].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[3].position.x, spots[3].position.y), bossMovementSpeed * 4); //moves towards the location



            yield return null;

        }

        anim.SetBool("is_walking", false);

        yield return new WaitForSeconds(10f);


        yield return null;

        StartCoroutine("BossSequence");
    }
}
