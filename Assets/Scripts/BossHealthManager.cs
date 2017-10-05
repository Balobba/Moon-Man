using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour {

    public int BossMaxHealth;
    public int BossCurrentHealth;

    private BossController bossController;
    //private SpriteRenderer BossSprite;
    Animator animator;
    public GameManager game;

    // Use this for initialization
    void Start()
    {
        bossController = GetComponent<BossController>();
        animator = gameObject.GetComponent<Animator>();
        //BossSprite = GetComponent<SpriteRenderer>();
        SetMaxHealth();

    }

    // Update is called once per frame
    void Update()
    {

        if (BossCurrentHealth <= 0)
        {
            animator.SetTrigger("is_dead");

            Destroy(gameObject);
            //ADD WIN CONDITION (maybe cut to win scene/cutscene with last item?)
        }
    }

    public void HurtEnemy(int damageToPlayer)
    {
        BossCurrentHealth -= damageToPlayer;

    }

    public void SetMaxHealth()
    {
        BossCurrentHealth = BossMaxHealth;

    }
}
