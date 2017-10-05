using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour //Keeps track of the enemy max health and current health
{

    public int EnemyMaxHealth;
    public int EnemyCurrentHealth;


    // Use this for initialization
    void Start()
    {

        SetMaxHealth();

    }

    // Update is called once per frame
    void Update()
    {

        if (EnemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damageToPlayer)
    {
        EnemyCurrentHealth -= damageToPlayer;

    }

    public void SetMaxHealth()
    {
        EnemyCurrentHealth = EnemyMaxHealth;

    }
}
