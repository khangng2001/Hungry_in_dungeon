using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private int health;
    private int maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
            Debug.Log("Die");
        }
    }
}
