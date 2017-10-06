using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthManager : MonoBehaviour {

    public int BossMaxHealth;
    public int BossCurrentHealth;

    private BossController bossController;
    Animator animator;
    public GameManager game;

    // Use this for initialization
    void Start()
    {
        bossController = GetComponent<BossController>();
        animator = gameObject.GetComponent<Animator>();
        SetMaxHealth();

    }

    void Update() //Keep it like this!
    {

        if (BossCurrentHealth <= 0)
        {
            //
            animator.SetTrigger("is_dead");
            bossController.enabled = false;
            game.WonGame();
            Destroy(gameObject, 10);
            //
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
